using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TourManager.Common.Types;

namespace TourManager.Service.Model.TourManager
{
    /// <summary>
    /// The booking validator
    /// </summary>
    public class AddEditBookingRequestModelValidator : AbstractValidator<AddEditBookingRequestModel>
    {
        /// <summary>
        /// Create new instance of booking validator
        /// </summary>
        public AddEditBookingRequestModelValidator()
        {
            RuleFor(booking => booking.Notes).NotEmpty().WithMessage("The booking notes field is requiered!");
        }
    }

    public class AddEditBookingRequestModel
    {
        /// <summary>
        /// The booking id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The booking type
        /// </summary>
        public BookingType Type { get; set; }

        /// <summary>
        /// The booking status
        /// </summary>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// The booking notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The booking property.
        /// </summary>
        public BookingPropertyModel BookingProperty { get; set; }

        /// <summary>
        /// The booking service.
        /// </summary>
        public BookingServiceModel BookingService { get; set; }

        /// <summary>
        /// The booking transportation
        /// </summary>
        public BookingTransportationModel BookingTransportation { get; set; }
    }
}
