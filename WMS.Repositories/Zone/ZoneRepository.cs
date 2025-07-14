using WMS.Contracts;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories
{
    public class ZoneRepository : RepositoryBase<Zone>, IZoneRepository
    {
        public ZoneRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}