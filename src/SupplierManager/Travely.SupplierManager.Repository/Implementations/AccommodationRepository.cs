using System.Linq;
using System.Threading.Tasks;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class AccommodationRepository : SupplierRepository<AccommodationEntity>
    {
        public AccommodationRepository(SupplierDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<AccommodationEntity> UpdateAsync(AccommodationEntity entity)
        {
            var existingAccommodation = await GetByIdAsync(entity.AgencyId, entity.Id);

            if (existingAccommodation != null)
            {
                DbContext.Entry(existingAccommodation).CurrentValues.SetValues(entity);

                // Location
                DbContext.Entry(existingAccommodation.Location).CurrentValues.SetValues(entity.Location);

                // Services
                foreach (var service in entity.Services)
                {
                    var existingService = DbContext.Set<AccommodationServiceEntity>()
                        .FirstOrDefault(p => p.Id == service.Id);

                    if (existingService == null)
                    {
                        existingAccommodation.Services.Add(service);
                    }
                    else
                    {
                        DbContext.Entry(existingService).CurrentValues.SetValues(service);
                    }
                }

                foreach (var service in existingAccommodation.Services)
                {
                    if (entity.Services.All(p => p.Id != service.Id))
                    {
                        DbContext.Remove(service);
                    }
                }

                // Rooms update or create
                foreach (var room in entity.Rooms)
                {
                    var existingRoom = DbContext.Set<RoomEntity>()
                        .FirstOrDefault(p => p.Id == room.Id);

                    if (existingRoom == null)
                    {
                        existingAccommodation.Rooms.Add(room);
                    }
                    else
                    {
                        DbContext.Entry(existingRoom).CurrentValues.SetValues(room);
                    }

                    foreach (var roomService in room.Services)
                    {
                        var existingRoomService = DbContext.Set<RoomServiceEntity>()
                            .FirstOrDefault(p => p.Id == roomService.Id);

                        if (existingRoomService == null)
                        {
                            existingRoom?.Services.Add(roomService);
                        }
                        else
                        {
                            DbContext.Entry(existingRoomService).CurrentValues.SetValues(roomService);
                        }
                    }
                }

                // Rooms remove
                foreach (var room in existingAccommodation.Rooms)
                {
                    if (entity.Rooms.All(p => p.Id != room.Id))
                    {
                        DbContext.Remove(room);
                    }

                    foreach (var existingRoomService in room.Services)
                    {
                        var roomEntity = entity.Rooms
                            .FirstOrDefault(p => p.Id == existingRoomService.Id);
                        if (roomEntity != null && roomEntity.Services.All(p => p.Id != existingRoomService.Id))
                        {
                            DbContext.Remove(existingRoomService);
                        }
                    }
                }

                // Attachments update or create
                foreach (var attachment in entity.Attachments)
                {
                    var existingAttachment = DbContext.Set<AttachmentEntity<AccommodationEntity>>()
                        .FirstOrDefault(p => p.Id == attachment.Id);

                    if (existingAttachment == null)
                    {
                        existingAccommodation.Attachments.Add(attachment);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                    }
                }

                // Attachments remove
                foreach (var existingAttachment in existingAccommodation.Attachments)
                {
                    if (entity.Attachments.All(p => p.Id != existingAttachment.Id))
                    {
                        DbContext.Remove(existingAttachment);
                    }
                }
            }

            await DbContext.SaveChangesAsync();

            return await GetByIdAsync(entity.AgencyId, entity.Id);
        }
    }
}