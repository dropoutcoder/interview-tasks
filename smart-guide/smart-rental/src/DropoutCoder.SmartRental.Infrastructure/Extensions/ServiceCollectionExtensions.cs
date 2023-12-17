using DropoutCoder.SmartRental.Infrastructure;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Services;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DropoutCoder.SmartRental.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string? databaseName = null)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IIdProvider<CarEntity>, IdProvider<CarEntity>>()
                .AddScoped<IIdProvider<CustomerEntity>, IdProvider<CustomerEntity>>()
                .AddScoped<IIdProvider<RentalEntity>, IdProvider<RentalEntity>>()
                .AddScoped(provider => provider.GetRequiredService<DatabaseContext>().Set<CarEntity>().Cast<ICar>())
                .AddScoped(provider => provider.GetRequiredService<DatabaseContext>().Set<CustomerEntity>().Cast<ICustomer>())
                .AddScoped(provider => provider.GetRequiredService<DatabaseContext>().Set<RentalEntity>().Cast<IRental>())
                .AddScoped<ICarStore, CarStore>()
                .AddScoped<ICustomerStore, CustomerStore>()
                .AddScoped<IRentalStore, RentalStore>()
                .AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName ?? "production");
                });

            return services;
        }
    }
}
