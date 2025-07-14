using WMS.Contracts;
using WMS.Models;
using WMS.DataLayer;

namespace WMS.Repositories
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(WMSContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}