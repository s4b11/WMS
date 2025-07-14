using WMS.Contracts.IUom;
using WMS.Models.Models.UomModel;
using WMS.DataLayer;

namespace WMS.Repositories
{
    public class UomRepository : RepositoryBase<Uom>, IUomRepository
    {
        public UomRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}