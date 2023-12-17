using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Operations.Abstraction;
using DropoutCoder.SmartRental.Operations.Commands;
using DropoutCoder.SmartRental.Operations.Internal.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace DropoutCoder.SmartRental.Operations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOperations(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IHandler<CreateCar, ICar>, CreateCarHadler>()
                .AddScoped<IHandler<CreateCustomer, ICustomer>, CreateCustomerHandler>()
                .AddScoped<IHandler<CreateRental, IRental>, CreateRentalHandler>()
                .AddScoped<IHandler<CancelRental, bool>, CancelRentalHandler>();

            return services;
        }
    }
}
