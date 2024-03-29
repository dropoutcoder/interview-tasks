﻿using DropoutCoder.SmartRental.Infrastructure;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Infrastructure.Database.ComplexTypes;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Internal.Stores
{
    internal class RentalStore : IRentalStore
    {
        public RentalStore(IIdProvider<RentalEntity> idProvider, DatabaseContext dbContext)
        {
            IdProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IIdProvider<RentalEntity> IdProvider { get; }

        public DatabaseContext DbContext { get; }

        public async Task<IRental> AddRentalAsync(
            int carId,
            int customerId,
            string licenceNumber,
            PersonalIdentification identificationDocument,
            DateTime pickupDate,
            DateTime returnDate,
            decimal price)
        {
            var id = await IdProvider
                .NextAsync();

            var entry = await DbContext
                .Set<RentalEntity>()
                .AddAsync(new RentalEntity
                {
                    CarId = carId,
                    CustomerId = customerId,
                    LicenceNumber = licenceNumber,
                    PersonalDocument = identificationDocument,
                    Id = id,
                    IsCancelled = false,
                    PickupDateTime = pickupDate,
                    Price = price,
                    ReturnDateTime = returnDate
                });

            try
            {
                var result = await DbContext
                    .SaveChangesAsync();

                Debug.Assert(result == 2);

                return entry.Entity;
            }
            catch (DbUpdateException due)
            {
                // log execution context
                throw new StoreException("We have encountered issue while trying to save car to the database.", due);
            }
        }

        public async Task<bool> CancelRental(int rentalId)
        {
            var entry = DbContext
                .Set<RentalEntity>()
                .Attach(new RentalEntity
                {
                    Id = rentalId
                });

            entry.Entity.IsCancelled = true;

            try
            {
                var result = await DbContext
                    .SaveChangesAsync();

                Debug.Assert(result == 1);

                return result == 1;
            }
            catch (DbUpdateException due)
            {
                // log execution context
                throw new StoreException("We have encountered issue while trying to save car to the database.", due);
            }
        }

        public async Task<bool> IsCancelled(int rentalId)
        {
            return await DbContext
                .Set<RentalEntity>()
                .AnyAsync(r => r.Id == rentalId && r.IsCancelled);
        }
    }
}
