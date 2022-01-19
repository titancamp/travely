using System.Linq;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Transportation;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.Filters
{
    public class TransportationFilter : Filter<TransportationEntity>
    {
        public TransportationType? Type { get; set; } 
        public string Car { get; set; }
        public TmRegion? TmRegion { get; set; }
        public string City { get; set; }
        
        public override IQueryable<TransportationEntity> Apply(IQueryable<TransportationEntity> query)
        {
            if (Type != null)
            {
                query = query.Where(e => e.Type == Type);
            }
            if (!string.IsNullOrEmpty(Car))
            {
                query = query.Where(e => e.Cars.Any(c => c.Model == Car));
            }
            if (TmRegion != null)
            {
                query = query.Where(e => e.TmRegion == TmRegion);
            }
            if (!string.IsNullOrEmpty(City))
            {
                query = query.Where(e => e.City == City);
            }

            return query;
        }
    }
}