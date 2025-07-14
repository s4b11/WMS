using WMS.Contracts.ICustomer;
using WMS.DataLayer;
using WMS.Models.Models.CustomerModel;

namespace WMS.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(WMSDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}