using System.Linq;
using TourEntities.Service.Accommodation;
using TourEntities.Service.Common.Location;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.Filters
{
    public class AccommodationFilter : Filter<AccommodationEntity>
    {
        public AccommodationType? Type { get; set; }
        public TmRegion? TmRegion { get; set; }
        public string City { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }

        public override IQueryable<AccommodationEntity> Apply(IQueryable<AccommodationEntity> query)
        {
            if (Type != null)
            {
                query = query.Where(e => e.Type == Type);
            }
            if (TmRegion != null)
            {
                query = query.Where(e => e.TmRegion == TmRegion);
            }
            if (!string.IsNullOrEmpty(City))
            {
                query = query.Where(e => e.City == City);
            }
            if (PriceFrom != null && PriceTo != null)
            {
                query = query.Where(e => e.Cost >= PriceFrom && e.Cost <= PriceTo);
            }
                
            return query;
        }
    }
}