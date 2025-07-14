using WMS.Contracts;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}