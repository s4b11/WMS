using WMS.Contracts.ICountry;
using WMS.Models.Models.CountryModel;
using WMS.DataLayer;

namespace WMS.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}