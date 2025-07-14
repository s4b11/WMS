using WMS.Contracts;
using WMS.Models;
using WMS.DataLayer;

namespace WMS.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}