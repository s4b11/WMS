using WMS.Contracts;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories
{
    public class VendorRepository : RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}