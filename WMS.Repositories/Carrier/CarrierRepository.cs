using WMS.Contracts.ICarrier;
using WMS.DataLayer;
using WMS.Models.Models.CarrierModel;

namespace WMS.Repositories
{
    public class CarrierRepository : RepositoryBase<Carrier>, ICarrierRepository
    {
        public CarrierRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}