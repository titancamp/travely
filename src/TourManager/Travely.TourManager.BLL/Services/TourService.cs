using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.TourManager.Core;
using Travely.TourManager.Core.Details;
using Travely.TourManager.DAL;

namespace Travely.TourManager.BLL
{
    public class TourService : ITourService
    {
        private readonly DataContext _dbContext;
        public TourService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateTourResponse> CreateTourAsync(TourDataRequest model)
        {
            var trans = _dbContext.Database.BeginTransaction();

            if (string.IsNullOrEmpty(model.Tour.TourName))
                throw new InvalidOperationException("The TourName is a required field");

            if (model.Tour.TourTypeId == 0)
                throw new InvalidOperationException("The TourTypeId is a required field");

            if (model.Tour.TourStatusId == 0)
                model.Tour.TourStatusId = 1;

            var tourData = new Tour
            {
                TourName = model.Tour.TourName,
                TourTypeId = model.Tour.TourTypeId,
                TourStatusId = model.Tour.TourStatusId,
                StartDate = model.Tour.StartDate,
                EndDate = model.Tour.EndDate,
                PartnerName = model.Tour.PartnerName,
                ArrivalDate = model.Tour.ArrivalDate,
                ArrivalTime = model.Tour.ArrivalTime,
                ArrivalLocation = model.Tour.ArrivalLocation,
                ArrivalFlightNumber = model.Tour.ArrivalFlightNumber,
                DepartureDate = model.Tour.DepartureDate,
                DepartureTime = model.Tour.DepartureTime,
                DepartureLocation = model.Tour.DepartureLocation,
                DepartureFlightNumber = model.Tour.DepartureFlightNumber,
                Notes = model.Tour.Notes,
                IsDeleted = model.Tour.IsDeleted,
                Cost = model.Tour.Cost,
                //CreatedBy = null,
                CreatedAt = DateTime.Now,
            };

            _dbContext.Tours.Add(tourData);

            await _dbContext.SaveChangesAsync();

            try
            {
                var groupData = new Group
                {
                    Id = tourData.Id,
                    NumberOfParticipants = model.Group.NumberOfParticipants,
                    NumberOfChildren = model.Group.NumberOfChildren,
                    Country = model.Group.Country,
                    Preferences = model.Group.Preferences,
                    IsDeleted = model.Group.IsDeleted,
                };

                _dbContext.Groups.Add(groupData);

                await _dbContext.SaveChangesAsync();

                foreach (var language in model.Group.LanguageId)
                {
                    var groupLanguageData = new GroupLanguage
                    {
                        GroupId = tourData.Id,
                        LanguageId = language
                    };

                    _dbContext.GroupLanguages.Add(groupLanguageData);
                }

                foreach (var attachment in model.Group.AttachmentName)
                {
                    var attachmentData = new Attachment
                    {
                        AttachmentName = attachment,
                        GroupId = tourData.Id,
                    };

                    _dbContext.Attachments.Add(attachmentData);
                }

                foreach (var participant in model.Group.Participants)
                {
                    var participantData = new Participant
                    {
                        GroupId = tourData.Id,
                        GenderId = participant.GenderId,
                        Age = participant.Age,
                        PassportNumber = participant.PassportNumber,
                        ContactNumber = participant.ContactNumber,
                        ContactEmail = participant.ContactEmail,
                        SpecialPreferences = participant.SpecialPreferences,
                        IsAllInclusive = participant.IsAllInclusive,
                    };

                    _dbContext.Participants.Add(participantData);
                }

                await _dbContext.SaveChangesAsync();

                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                throw new InvalidOperationException("Failed insert");
            }

            return new CreateTourResponse { Id = tourData.Id };
        }

        public async Task<TourDataResponse> GetTourByIdAsync(int id)
        {
            var tour = await _dbContext.Tours.Where(v => v.Id == id).FirstOrDefaultAsync();

            var groupAttachments = _dbContext.Attachments.Where(v => v.GroupId == id).ToList();
            var attachmentNames = new List<string>();
            foreach (var attachment in groupAttachments)
            {
                attachmentNames.Add(attachment.AttachmentName);
            }

            var groupParticipants = _dbContext.Participants.Where(v => v.GroupId == id).ToList();
            var participants = new List<ParticipantResponse>();

            foreach (var participant in groupParticipants)
            {
                participants.Add(new ParticipantResponse {ParticipantId = participant.Id , GenderId = participant.GenderId, Age = participant.Age,  PassportNumber = participant.PassportNumber, ContactNumber = participant.ContactNumber, ContactEmail = participant.ContactEmail, IsAllInclusive = participant.IsAllInclusive, SpecialPreferences = participant.SpecialPreferences});
            }

            if (tour == null)
                throw new InvalidOperationException("Tour not found.");

            return await _dbContext.Tours.Where(v => v.Id == id)
                .Include(v => v.TourType)
                .Include(v => v.TourStatus)
                .Include(v => v.TourGroup)
                .Select(s => new TourDataResponse
                {
                    Tour = new TourResponse
                    {
                        Id = id,
                        TourName = s.TourName,
                        TourType = new TourTypeResponse { TourTypeId = s.TourType.Id, TourTypeName = s.TourType.TypeName },
                        TourStatus = new TourStatusResponse { TourStatusId = s.TourStatusId, TourStatusName = s.TourStatus.StatusName },
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        PartnerName = s.PartnerName,
                        ArrivalDate = s.ArrivalDate,
                        ArrivalTime = s.ArrivalTime,
                        ArrivalLocation = s.ArrivalLocation,
                        ArrivalFlightNumber = s.ArrivalFlightNumber,
                        DepartureDate = s.DepartureDate,
                        DepartureTime = s.DepartureTime,
                        DepartureLocation = s.DepartureLocation,
                        DepartureFlightNumber = s.DepartureFlightNumber,
                        Notes = s.Notes,
                        IsDeleted = s.IsDeleted,
                        Cost = s.Cost,
                        CreatedBy = s.CreatedBy,
                        CreatedAt = s.CreatedAt,
                        LastEditedBy = s.LastEditedBy,
                        LastEditedAt = s.LastEditedAt
                    },

                    Group = s.TourGroup == null ? null : new GroupResponse
                    {
                        TourId = s.Id,
                        Country = s.TourGroup.Country,
                        NumberOfParticipants = s.TourGroup.NumberOfParticipants,
                        NumberOfChildren = s.TourGroup.NumberOfChildren,
                        Preferences = s.TourGroup.Preferences,
                        Languages = s.TourGroup.GroupLanguages.Where(v => v.GroupId == id).Select(x => x.LanguageId).ToList(),
                        Attachments = attachmentNames,
                        Participants = participants,
                        IsDeleted = s.TourGroup.IsDeleted
                    }
                }).FirstOrDefaultAsync();
        }

        public async Task UpdateTourAsync(int id, TourDataRequest model)
        {
            var tourData = await _dbContext.Tours.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (tourData == null)
                throw new InvalidOperationException("Tour not found");

            if (string.IsNullOrEmpty(model.Tour.TourName))
                throw new InvalidOperationException("The TourName is a required field");

            if (model.Tour.TourTypeId == 0)
                throw new InvalidOperationException("The TourType is a required field");

            tourData.TourName = model.Tour.TourName;
            tourData.TourTypeId = model.Tour.TourTypeId;
            tourData.TourStatusId = model.Tour.TourStatusId;
            tourData.StartDate = model.Tour.StartDate;
            tourData.EndDate = model.Tour.EndDate;
            tourData.PartnerName = model.Tour.PartnerName;
            tourData.ArrivalDate = model.Tour.ArrivalDate;
            tourData.ArrivalTime = model.Tour.ArrivalTime;
            tourData.ArrivalLocation = model.Tour.ArrivalLocation;
            tourData.ArrivalFlightNumber = model.Tour.ArrivalFlightNumber;
            tourData.DepartureDate = model.Tour.DepartureDate;
            tourData.DepartureTime = model.Tour.DepartureTime;
            tourData.DepartureLocation = model.Tour.DepartureLocation;
            tourData.DepartureFlightNumber = model.Tour.DepartureFlightNumber;
            tourData.Notes = model.Tour.Notes;
            tourData.IsDeleted = model.Tour.IsDeleted;
            tourData.Cost = model.Tour.Cost;
            //data.LastEditedBy = model.LastEditedBy;
            tourData.LastEditedAt = DateTime.Now;

            var groupData = await _dbContext.Groups.Where(a => a.Id == id).FirstOrDefaultAsync();

            groupData.NumberOfParticipants = model.Group.NumberOfParticipants;
            groupData.NumberOfChildren = model.Group.NumberOfChildren;
            groupData.Country = model.Group.Country;
            groupData.IsDeleted = model.Group.IsDeleted;
            groupData.Preferences = model.Group.Preferences;

            foreach (var attachment in model.Group.AttachmentName)
            {
                var attachmentData = new Attachment
                {
                    AttachmentName = attachment,
                    GroupId = tourData.Id,
                };

                _dbContext.Attachments.Add(attachmentData);
            }

            var groupLang = await _dbContext.GroupLanguages.Where(n => n.GroupId == id).FirstOrDefaultAsync();

            try
            {
                _dbContext.GroupLanguages.Remove(groupLang);
            }
            catch (Exception ex)
            {

            }

            foreach (var language in model.Group.LanguageId)
            {
                var groupLanguageData = new GroupLanguage
                {
                    GroupId = tourData.Id,
                    LanguageId = language
                };

                _dbContext.GroupLanguages.Add(groupLanguageData);
            }

            foreach (var participant in model.Group.Participants)
            {
                var participantData = new Participant
                {
                    GenderId = participant.GenderId,
                    Age = participant.Age,
                    PassportNumber = participant.PassportNumber,
                    ContactNumber = participant.ContactNumber,
                    ContactEmail = participant.ContactEmail,
                    SpecialPreferences = participant.SpecialPreferences,
                    IsAllInclusive = participant.IsAllInclusive
                };
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TourDataResponse>> GetToursAsync()
        {
            IQueryable<Tour> data = _dbContext.Tours;

            return await data.Select(s => new TourDataResponse
            {
                Tour = new TourResponse
                {
                    Id = s.Id,
                    TourName = s.TourName,
                    TourType = new TourTypeResponse { TourTypeId = s.TourType.Id, TourTypeName = s.TourType.TypeName },
                    TourStatus = new TourStatusResponse { TourStatusId = s.TourStatusId, TourStatusName = s.TourStatus.StatusName },
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    PartnerName = s.PartnerName,
                    ArrivalDate = s.ArrivalDate,
                    ArrivalTime = s.ArrivalTime,
                    ArrivalLocation = s.ArrivalLocation,
                    ArrivalFlightNumber = s.ArrivalFlightNumber,
                    DepartureDate = s.DepartureDate,
                    DepartureTime = s.DepartureTime,
                    DepartureLocation = s.DepartureLocation,
                    DepartureFlightNumber = s.DepartureFlightNumber,
                    Notes = s.Notes,
                    IsDeleted = s.IsDeleted,
                    Cost = s.Cost,
                    CreatedBy = s.CreatedBy,
                    CreatedAt = s.CreatedAt,
                    LastEditedBy = s.LastEditedBy,
                    LastEditedAt = s.LastEditedAt
                },

                Group = s.TourGroup == null ? null : new GroupResponse
                {
                    TourId = s.Id,
                    Country = s.TourGroup.Country,
                    NumberOfParticipants = s.TourGroup.NumberOfParticipants,
                    NumberOfChildren = s.TourGroup.NumberOfChildren,
                    IsDeleted = s.TourGroup.IsDeleted,
                    Preferences = s.TourGroup.Preferences,
                    Attachments = s.TourGroup.Attachments.Where(v => v.GroupId == s.Id).Select(v => v.AttachmentName).ToList(),
                    Languages = s.TourGroup.GroupLanguages.Where(v => v.GroupId == s.Id).Select(v => v.LanguageId).ToList(),
                    //Languages = data.Where(v => v.TourGroup.Id == s.Id).Select(v => new LanguageResponse
                    //{
                    //    LanguageId = s.TourGroup.GroupLanguages.Where(v => v.GroupId == s.Id).FirstOrDefault().LanguageId,
                    //    LanguageName = s.TourGroup.GroupLanguages.Where(v => v.GroupId == s.Id).FirstOrDefault().Language.LanguageName
                    //}).ToList(),
                    Participants = data.Where(v => v.TourGroup.Id == s.Id).Select(v => new ParticipantResponse
                    {
                        ParticipantId = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().Id,
                        //Gender = s.TourGroup.Participants.Where(v => v.GroupId == s.Id)
                        GenderId = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().GenderId,
                        Age = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().Age,
                        PassportNumber = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().PassportNumber,
                        ContactNumber = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().ContactNumber,
                        ContactEmail = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().ContactNumber,
                        SpecialPreferences = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().SpecialPreferences,
                        IsAllInclusive = s.TourGroup.Participants.Where(v => v.GroupId == s.Id).FirstOrDefault().IsAllInclusive
                    }).ToList()
                }
            }).ToListAsync();
        }

        public async Task DeleteTourAsync(int id)
        {
            var data = await _dbContext.Tours.Where(n => n.Id == id).FirstOrDefaultAsync();
            var groupData = await _dbContext.Groups.Where(n => n.Id == id).FirstOrDefaultAsync();
            var groupLangData = _dbContext.GroupLanguages.Where(n => n.GroupId == id).FirstOrDefault();
            var attachmentData = _dbContext.Attachments.Where(n => n.GroupId == id).FirstOrDefault();
            var participantData = _dbContext.Participants.Where(n => n.GroupId == id).FirstOrDefault();

            if (data == null)
                throw new InvalidOperationException("Tour not found.");

            if(groupLangData == null)
                throw new InvalidOperationException("No Languages in the Group.");

            if (attachmentData == null)
                throw new InvalidOperationException("No Attachments in the Group.");

            //_dbContext.Tours.Remove(data);
            try
            {
                _dbContext.GroupLanguages.Remove(groupLangData);
                _dbContext.Attachments.Remove(attachmentData);
                _dbContext.Participants.Remove(participantData);
            }
            catch (Exception ex)
            {

            }
            data.IsDeleted = true;
            data.TourGroup.IsDeleted = true;
            groupData.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}
