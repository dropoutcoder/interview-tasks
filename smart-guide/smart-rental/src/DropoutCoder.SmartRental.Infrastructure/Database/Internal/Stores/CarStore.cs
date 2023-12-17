using DropoutCoder.SmartRental.Infrastructure;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Internal.Stores
{
    internal class CarStore : ICarStore
    {
        public CarStore(IIdProvider<CarEntity> idProvider, DatabaseContext dbContext)
        {
            IdProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IIdProvider<CarEntity> IdProvider { get; }

        public DatabaseContext DbContext { get; }

        public async Task<ICar> AddCarAsync(string registrationNumber, string name)
        {
            var id = await IdProvider
                .NextAsync();

            var entry = await DbContext
            .Set<CarEntity>()
            .AddAsync(new CarEntity
            {
                Id = id,
                Name = name,
                RegistrationNumber = registrationNumber,
            });

            try
            {
                var result = await DbContext
                    .SaveChangesAsync();

                Debug.Assert(result == 1);

                return entry.Entity;
            }
            catch (DbUpdateException due)
            {
                // log execution context
                throw new StoreException("We have encountered issue while trying to save car to the database.", due);
            }
        }

        public async Task<bool> RegistrationNumberExistsAsync(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException($"'{nameof(registrationNumber)}' cannot be null or whitespace.", nameof(registrationNumber));
            }

            return await DbContext
            .Set<CarEntity>()
            .AnyAsync(c => c.RegistrationNumber == registrationNumber);
        }
    }
}
