using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class FoodRepository : SupplierRepository<FoodEntity>
    {
        public FoodRepository(SupplierDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<FoodEntity> UpdateAsync(FoodEntity entity)
        {
            var existingFood = await GetByIdAsync(entity.AgencyId, entity.Id);

            if (existingFood != null)
            {
                DbContext.Entry(existingFood).CurrentValues.SetValues(entity);

                // Location
                DbContext.Entry(existingFood.Location).CurrentValues.SetValues(entity.Location);
                
                // Menu
                DbContext.Entry(existingFood.Menu).CurrentValues.SetValues(entity.Menu);
                var existingMenu = DbContext.Set<MenuEntity>().FirstOrDefault(p => p.Id == entity.Menu.Id);
                
                // Menu Tags update or create
                foreach (var tag in entity.Menu.Tags)
                {
                    var existingTag = DbContext.Set<TagEntity>()
                        .FirstOrDefault(p => p.Id == tag.Id);

                    if (existingTag == null)
                    {
                        existingMenu?.Tags.Add(tag);
                    }
                    else
                    {
                        DbContext.Entry(existingTag).CurrentValues.SetValues(tag);
                    }
                }
                
                // Menu Attachments update or create
                foreach (var attachment in entity.Menu.Attachments)
                {
                    var existingAttachment = DbContext.Set<AttachmentEntity<MenuEntity>>()
                        .FirstOrDefault(p => p.Id == attachment.Id);

                    if (existingAttachment == null)
                    {
                        existingMenu?.Attachments.Add(attachment);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                    }
                }

                // Menu remove
                if (existingMenu != null)
                {
                    // Menu Tags remove
                    foreach (var existingTag in existingMenu.Tags)
                    {
                        if (entity.Menu.Tags.All(p => p.Id != existingTag.Id))
                        {
                            DbContext.Remove(existingTag);
                        }
                    }
                    
                    // Menu Attachments remove
                    foreach (var existingAttachment in existingMenu.Attachments)
                    {
                        if (entity.Menu.Attachments.All(p => p.Id != existingAttachment.Id))
                        {
                            DbContext.Remove(existingAttachment);
                        }
                    }
                }

                // Attachments update or create
                foreach (var attachment in entity.Attachments)
                {
                    var existingAttachment = DbContext.Set<AttachmentEntity<FoodEntity>>()
                        .FirstOrDefault(p => p.Id == attachment.Id);

                    if (existingAttachment == null)
                    {
                        existingFood.Attachments.Add(attachment);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                    }
                }

                // Attachments remove
                foreach (var existingAttachment in existingFood.Attachments)
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