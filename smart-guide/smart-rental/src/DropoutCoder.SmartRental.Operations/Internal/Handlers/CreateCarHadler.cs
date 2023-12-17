using DropoutCoder.SmartRental.Infrastructure.Database;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction;
using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Operations.Commands;
using Microsoft.EntityFrameworkCore;

namespace DropoutCoder.SmartRental.Operations.Internal.Handlers
{
    internal class CreateCarHadler : Handler<CreateCar, ICar>
    {
        public CreateCarHadler(ICarStore store)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
        }

        public ICarStore Store { get; }

        protected override async Task<ICar> ExecuteCoreAsync(CreateCar command)
        {
            try
            {
                return await Store
                    .AddCarAsync(command.RegistrationNumber, command.Name);
            }
            catch (StoreException se)
            {
                // log and rethrow
                throw new OperationException(command, "We have encountered issue while trying to save car to the database.", se);
            }
        }

        protected override async Task<bool> ValidateAsync(CreateCar command)
        {
            // additional validations

            var exists = await Store
                .RegistrationNumberExistsAsync(command.RegistrationNumber);

            return !exists;
        }
    }
}
