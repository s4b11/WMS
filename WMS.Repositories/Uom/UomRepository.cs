using WMS.Contracts;
using WMS.Models;
using WMS.DataLayer;

namespace WMS.Repositories
{
    public class UomRepository : RepositoryBase<Uom>, IUomRepository
    {
        public UomRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}