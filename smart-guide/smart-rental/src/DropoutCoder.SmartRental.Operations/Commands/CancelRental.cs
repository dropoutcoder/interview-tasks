using System.ComponentModel.DataAnnotations;

namespace DropoutCoder.SmartRental.Operations.Commands
{
    /// <summary>
    /// Defines cancel rental operation command
    /// </summary>
    public class CancelRental
    {
        /// <summary>
        /// Rental identifier
        /// </summary>
        [Required]
        public int RentalId { get; set; }
    }
}
