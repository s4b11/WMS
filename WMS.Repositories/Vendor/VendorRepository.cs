using WMS.Contracts.IVendor;
using WMS.DataLayer;
using WMS.Models.Models.VendorModel;

namespace WMS.Repositories
{
    public class VendorRepository : RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}