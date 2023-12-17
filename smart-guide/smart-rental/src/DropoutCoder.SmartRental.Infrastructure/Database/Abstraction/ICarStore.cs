using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Abstraction
{
    public interface ICarStore
    {
        public Task<ICar> AddCarAsync(
            string registrationNumber,
            string name);

        public Task<bool> RegistrationNumberExistsAsync(string registrationNumber);
    }
}
