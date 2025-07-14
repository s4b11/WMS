using Microsoft.EntityFrameworkCore;
using WMS.Contracts.IRepository;
using WMS.Repositories;
using WMS.DataLayer;
using WMS.Models.Models;

namespace WMS.Repositories.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WMSDbContext context) : base(context) 
        {

        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await GetSingleByConditionAsync(u => u.Username == username);
        }
    }

}
