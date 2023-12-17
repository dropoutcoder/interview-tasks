using System.ComponentModel.DataAnnotations;
using static DropoutCoder.SmartRental.Infrastructure.Database.ComplexTypes.PersonalIdentification;

namespace DropoutCoder.SmartRental.Operations.Commands
{
    public class CreateRental
    {
        /// <summary>
        /// Rental car reference identifier
        /// </summary>
        [Required]
        public int CarId { get; set; }

        /// <summary>
        /// Rental customer reference identifier
        /// </summary>
        [Required]
        public int CustomerId { get; set; }

        /// <summary>
        /// Driving licence number
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string LicenceNumber { get; set; }

        /// <summary>
        /// Personal identification document type
        /// </summary>
        [Required]
        public IdentificationType PersonalDocumentType { get; set; }

        /// <summary>
        /// Personal identification document number
        /// </summary>
        [Required]
        public int PersonalDocumentNumber { get; set; }

        /// <summary>
        /// Pickup date and time
        /// </summary>
        [Required]
        public DateTime PickupDateTime { get; set; }

        /// <summary>
        /// Total price of the rental
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        /// <summary>
        /// Return date and time
        /// </summary>
        [Required]
        public DateTime ReturnDateTime { get; set; }
    }
}
