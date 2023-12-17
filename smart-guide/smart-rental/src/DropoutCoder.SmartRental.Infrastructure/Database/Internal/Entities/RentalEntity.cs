using DropoutCoder.SmartRental.Infrastructure.Database.Abstraction.Types;
using DropoutCoder.SmartRental.Infrastructure.Database.ComplexTypes;
using DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities.Abstraction;

namespace DropoutCoder.SmartRental.Infrastructure.Database.Internal.Entities
{
    /// <summary>
    /// Defines rental database entity
    /// </summary>
    internal class RentalEntity : DbEntity<int>, IRental
    {

        /// <summary>
        /// Rental car reference identifier
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Rental customer reference identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Flag indicating rental was cancelled
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Driving licence number
        /// </summary>
        public string LicenceNumber { get; set; }

        /// <summary>
        /// Personal identification document
        /// </summary>
        public PersonalIdentification PersonalDocument { get; set; }

        /// <summary>
        /// Pickup date and time
        /// </summary>
        public DateTime PickupDateTime { get; set; }

        /// <summary>
        /// Total price of the rental
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Return date and time
        /// </summary>
        public DateTime ReturnDateTime { get; set; }
    }
}
