using DropoutCoder.SmartRental.Infrastructure;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Infrastructure.Database.ComplexTypes;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Internal.Stores
{
    internal class CustomerStore : ICustomerStore
    {
        public CustomerStore(IIdProvider<CustomerEntity> idProvider, DatabaseContext dbContext)
        {
            IdProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IIdProvider<CustomerEntity> IdProvider { get; }

        public DatabaseContext DbContext { get; }

        public IQueryable<ICustomer> Query => DbContext
            .Set<CustomerEntity>()
            .Cast<ICustomer>();

        public async Task<ICustomer> AddCustomerAsync(
            string givenName,
            string surname,
            string street,
            string city,
            string postalCode,
            DateTime dateOfBirth)
        {
            var id = await IdProvider
                .NextAsync();

            var entry = await DbContext
                .Set<CustomerEntity>()
                .AddAsync(new CustomerEntity
                {
                    Address = Address.Create(street, city, postalCode),
                    DateOfBirth = dateOfBirth,
                    GivenName = givenName,
                    Id = id,
                    Surname = surname
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
    }
}
