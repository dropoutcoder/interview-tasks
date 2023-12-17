using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Infrastructure.Database.ComplexTypes;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Abstraction
{
    public interface IRentalStore
    {
        public Task<IRental> AddRentalAsync(
            int carId,
            int customerId,
            string licenceNumber,
            PersonalIdentification identificationDocument,
            DateTime pickupDate,
            DateTime returnDate,
            decimal price);

        public Task<bool> CancelRental(int rentalId);

        public Task<bool> IsCancelled(int rentalId);
    }
}
