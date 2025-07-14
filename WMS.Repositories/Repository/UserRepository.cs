using WMS.Contracts;
using WMS.DataLayer;
using WMS.Models;

namespace WMS.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WMSContext context) : base(context) 
        {

        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await GetSingleByConditionAsync(u => u.Username == username);
        }
    }

}
