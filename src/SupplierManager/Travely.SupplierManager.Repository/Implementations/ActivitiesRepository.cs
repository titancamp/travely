using System.Linq;
using System.Threading.Tasks;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class ActivitiesRepository : SupplierRepository<ActivitiesEntity>
    {
        public ActivitiesRepository(SupplierDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<ActivitiesEntity> UpdateAsync(ActivitiesEntity entity)
        {
            var existingActivities = await GetByIdAsync(entity.AgencyId, entity.Id);
            
            if (existingActivities != null)
            {
                DbContext.Entry(existingActivities).CurrentValues.SetValues(entity);
                // Attributes update or create
                foreach (var attribute in entity.Attributes)
                {
                    var existingAttachment = DbContext.Set<AttributeEntity>()
                        .FirstOrDefault(p => p.Id == attribute.Id);

                    if (existingAttachment == null)
                    {
                        existingActivities.Attributes.Add(attribute);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attribute);
                    }
                }

                // Attributes remove
                foreach (var attribute in existingActivities.Attributes)
                {
                    if (entity.Attributes.All(p => p.Id != attribute.Id))
                    {
                        DbContext.Remove(attribute);
                    }
                }
            
                // Attachments update or create
                foreach (var attachment in entity.Attachments)
                {
                    var existingAttachment = DbContext.Set<AttachmentEntity<ActivitiesEntity>>()
                        .FirstOrDefault(p => p.Id == attachment.Id);

                    if (existingAttachment == null)
                    {
                        existingActivities.Attachments.Add(attachment);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                    }
                }

                // Attachments remove
                foreach (var existingAttachment in existingActivities.Attachments)
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