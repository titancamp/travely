using System.Linq;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Guide;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.Filters
{
    public class GuidesFilter : Filter<GuidesEntity>
    {
        public GuideType? Type { get; set; }
        public TmRegion? TmRegion { get; set; }
        public string City { get; set; }

        public override IQueryable<GuidesEntity> Apply(IQueryable<GuidesEntity> query)
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

            return query;
        }
    }
}