using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TourManager.Service.Model.TourManager
{
    /// <summary>
    /// The tour validator
    /// </summary>
    public class AddEditTourRequestModelValidator : AbstractValidator<AddEditTourRequestModel>
    {
        /// <summary>
        /// Create new instance of tour validator
        /// </summary>
        public AddEditTourRequestModelValidator()
        {
            RuleFor(tour => tour.Name).NotEmpty().WithMessage("The tour name field is requiered!");
            RuleFor(tour => tour.Notes).NotEmpty().WithMessage("The tour notes field is requiered!");
            RuleFor(tour => tour.Bookings).NotEmpty().WithMessage("The tour should contain at least one destination!");
            RuleForEach(tour => tour.Bookings).NotEmpty().WithMessage("The tour can not contain empty booking!");
            RuleFor(tour => tour.ClientIds).NotEmpty().WithMessage("The tour should contain at least one client!");
        }
    }

    public class AddEditTourRequestModel
    {
        /// <summary>
        /// The tour id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Is tour package
        /// </summary>
        public bool? IsPackage { get; set; }

        /// <summary>
        /// The tour name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The tour price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The tour origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// The tour start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The tour end date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The tour pick up time
        /// </summary>
        public DateTime? PickUpTime { get; set; }

        /// <summary>
        /// The tour pick up details
        /// </summary>
        public string PickUpDetails { get; set; }

        /// <summary>
        /// The tour drop off time
        /// </summary>
        public DateTime? DropOffTime { get; set; }

        /// <summary>
        /// The tour drop off details
        /// </summary>
        public string DropOffDetails { get; set; }

        /// <summary>
        /// The tour notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The tour bookings collection
        /// </summary>
        public List<AddEditBookingRequestModel> Bookings { get; set; }

        /// <summary>
        /// The tour clients collection
        /// </summary>
        public List<int> ClientIds { get; set; }
    }
}
