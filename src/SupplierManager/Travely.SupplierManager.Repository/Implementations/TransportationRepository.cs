using System.Linq;
using System.Threading.Tasks;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class TransportationRepository : SupplierRepository<TransportationEntity>
    {
        
        public TransportationRepository(SupplierDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TransportationEntity> UpdateAsync(TransportationEntity entity)
        {
            var existingTransportation = await GetByIdAsync(entity.AgencyId, entity.Id);

            if (existingTransportation != null)
            {
                DbContext.Entry(existingTransportation).CurrentValues.SetValues(entity);

                // Location
                DbContext.Entry(existingTransportation.Location).CurrentValues.SetValues(entity.Location);

                // Drivers update or create
                foreach (var driver in entity.Drivers)
                {
                    var existingDriver = DbContext.Set<DriverEntity>()
                        .FirstOrDefault(p => p.Id == driver.Id);

                    if (existingDriver == null)
                    {
                        existingTransportation.Drivers.Add(driver);
                    }
                    else
                    {
                        DbContext.Entry(existingDriver).CurrentValues.SetValues(driver);
                    }

                    foreach (var licenseType in driver.LicenseTypes)
                    {
                        var existingLicenseType = DbContext.Set<LicenseTypeEntity>()
                            .FirstOrDefault(p => p.Id == licenseType.Id);

                        if (existingLicenseType == null)
                        {
                            existingDriver?.LicenseTypes.Add(licenseType);
                        }
                        else
                        {
                            DbContext.Entry(existingLicenseType).CurrentValues.SetValues(licenseType);
                        }
                    }
                    
                    foreach (var language in driver.Languages)
                    {
                        var existingLanguage = DbContext.Set<LanguageEntity<DriverEntity>>()
                            .FirstOrDefault(p => p.Id == language.Id);

                        if (existingLanguage == null)
                        {
                            existingDriver?.Languages.Add(language);
                        }
                        else
                        {
                            DbContext.Entry(existingLanguage).CurrentValues.SetValues(language);
                        }
                    }
                }

                foreach (var existingDriver in existingTransportation.Drivers)
                {
                    foreach (var existingLicenseType in existingDriver.LicenseTypes)
                    {
                        var driver = entity.Drivers
                            .FirstOrDefault(p => p.Id == existingDriver.Id);
                        if (driver != null && driver.LicenseTypes.All(p => p.Id != existingLicenseType.Id))
                        {
                            DbContext.Remove(existingLicenseType);
                        }
                    }
                    
                    foreach (var existingLanguage in existingDriver.Languages)
                    {
                        var driver = entity.Drivers
                            .FirstOrDefault(p => p.Id == existingDriver.Id);
                        if (driver != null && driver.Languages.All(p => p.Id != existingLanguage.Id))
                        {
                            DbContext.Remove(existingLanguage);
                        }
                    }
                    
                    if (entity.Drivers.All(p => p.Id != existingDriver.Id))
                    {
                        DbContext.Remove(existingDriver);
                    }
                }

                // Cars
                foreach (var car in entity.Cars)
                {
                    var existingCar = DbContext.Set<CarEntity>()
                        .FirstOrDefault(p => p.Id == car.Id);

                    if (existingCar == null)
                    {
                        existingTransportation.Cars.Add(car);
                    }
                    else
                    {
                        DbContext.Entry(existingCar).CurrentValues.SetValues(car);
                    }
                }

                foreach (var existingCar in existingTransportation.Cars)
                {
                    if (entity.Cars.All(p => p.Id != existingCar.Id))
                    {
                        DbContext.Remove(existingCar);
                    }
                }
                
                // Attachments
                foreach (var attachment in entity.Attachments)
                {
                    var existingAttachment = DbContext.Set<AttachmentEntity<TransportationEntity>>()
                        .FirstOrDefault(p => p.Id == attachment.Id);

                    if (existingAttachment == null)
                    {
                        existingTransportation.Attachments.Add(attachment);
                    }
                    else
                    {
                        DbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                    }
                }

                foreach (var existingAttachment in existingTransportation.Attachments)
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