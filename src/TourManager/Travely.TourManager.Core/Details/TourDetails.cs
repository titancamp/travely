using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.TourManager.Core.Details
{

    public class GroupRequest
    {
        public int NumberOfParticipants { get; set; }
        public int NumberOfChildren { get; set; }
        public string Country { get; set; }
        public IList<int> LanguageId { get; set; }
        public IList<string> Preferences { get; set; }
        public IList<string> AttachmentName { get; set; }
        public IList<ParticipantRequest> Participants { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class GroupResponse
    {
        public int TourId { get; set; }
        public int NumberOfParticipants { get; set; }
        public int NumberOfChildren { get; set; }
        public string Country { get; set; }
        public IList<int> Languages { get; set; }
        public IList<string> Preferences { get; set; }
        public IList<string> Attachments { get; set; }
        public IList<ParticipantResponse> Participants { get; set; }
        public bool IsDeleted { get; set; } 
    }

    public class ParticipantRequest
    {
        public int GenderId { get; set; }
        public int Age { get; set; }
        public string PassportNumber { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string SpecialPreferences { get; set; }
        public bool IsAllInclusive { get; set; }
    }

    public class ParticipantResponse
    {
        public int ParticipantId { get; set; }
        public int GenderId { get; set; }
        public int Age { get; set; }
        public string PassportNumber { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string SpecialPreferences { get; set; }
        public bool IsAllInclusive { get; set; }
    }

    public class TourRequest
    {
        public string TourName { get; set; }
        public int TourTypeId { get; set; }
        public int TourStatusId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PartnerName { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public string ArrivalLocation { get; set; }
        public string ArrivalFlightNumber { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public string DepartureLocation { get; set; }
        public string DepartureFlightNumber { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Cost { get; set; }
    }

    public class TourResponse 
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public TourTypeResponse TourType { get; set; }
        public TourStatusResponse TourStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PartnerName { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public string ArrivalLocation { get; set; }
        public string ArrivalFlightNumber { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public string DepartureLocation { get; set; }
        public string DepartureFlightNumber { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Cost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime? LastEditedAt { get; set; }
    }

    public class CreateTourResponse
    {
        public int Id { get; set; }
    }

    public class TourDataRequest
    {
        public TourRequest Tour { get; set; }

        public GroupRequest Group { get; set; }
    }

    public class TourDataResponse
    {
        public TourResponse Tour { get; set; }

        public GroupResponse Group { get; set; }
    }
}
