using WMS.Contracts.IZone;
using WMS.DataLayer;
using WMS.Models.Models.ZoneModel;

namespace WMS.Repositories
{
    public class ZoneRepository : RepositoryBase<Zone>, IZoneRepository
    {
        public ZoneRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}