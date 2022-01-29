using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using TourEntities.Service.Food;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class GuidesRepository : SupplierRepository<GuidesEntity>
    {
        public GuidesRepository(SupplierDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<GuidesEntity> UpdateAsync(GuidesEntity entity)
        {
            var existingGuides = await GetByIdAsync(entity.AgencyId, entity.Id);

            if (existingGuides != null)
            {
                DbContext.Entry(existingGuides).CurrentValues.SetValues(entity);

                // Location
                DbContext.Entry(existingGuides.Location).CurrentValues.SetValues(entity.Location);

                // Guides update or create
                foreach (var guide in entity.Guides)
                {
                    var existingGuide = DbContext.Set<GuideEntity>() 
                        .FirstOrDefault(p => p.Id == guide.Id);

                    if (existingGuide == null)
                    {
                        existingGuides.Guides.Add(guide);
                    }
                    else
                    {
                        DbContext.Entry(existingGuide).CurrentValues.SetValues(guide);
                    }

                    foreach (var language in guide.Languages)
                    {
                        var existingLanguage = DbContext.Set<LanguageEntity<GuideEntity>>()
                            .FirstOrDefault(p => p.Id == language.Id);

                        if (existingLanguage == null)
                        {
                            existingGuide?.Languages.Add(language);
                        }
                        else
                        {
                            DbContext.Entry(existingLanguage).CurrentValues.SetValues(language);
                        }
                    }
                }

                // Guides remove
                foreach (var existingGuide in existingGuides.Guides)
                {
                    foreach (var existingLanguage in existingGuide.Languages)
                    {
                        var guide = entity.Guides
                            .FirstOrDefault(p => p.Id == existingGuide.Id);
                        if (guide != null && guide.Languages.All(p => p.Id != existingLanguage.Id))
                        {
                            Console.WriteLine($"deleting id {existingLanguage.Id} name {existingLanguage.Name}");
                            DbContext.Remove(existingLanguage);
                        }
                    }
                    
                    if (entity.Guides.All(p => p.Id != existingGuide.Id))
                    {
                        DbContext.Remove(existingGuide);
                    }
                }

                // Attachments update or create
                foreach (var attachment in entity.Attachments)
                {
                    var existingAttachment = DbContext.Set<AttachmentEntity<GuidesEntity>>()
                        .FirstOrDefault(p => p.Id == attachment.Id);

                    if (existingAttachment == null)
                    {
                        existingGuides.Attachments.Add(attachment);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                    }
                }

                // Attachments remove
                foreach (var existingAttachment in existingGuides.Attachments)
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