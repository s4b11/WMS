using WMS.Contracts;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories
{
    public class CarrierRepository : RepositoryBase<Carrier>, ICarrierRepository
    {
        public CarrierRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}