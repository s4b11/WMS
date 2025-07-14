using WMS.Contracts.ICompany;
using WMS.DataLayer;
using WMS.Models.Models.CompanyModel;

namespace WMS.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}