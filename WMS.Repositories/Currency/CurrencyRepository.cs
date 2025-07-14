using WMS.Contracts.ICurrency;
using WMS.Models.Models.CurrencyModel;
using WMS.DataLayer;

namespace WMS.Repositories
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}