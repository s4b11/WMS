using WMS.Models.Models;
using WMS.Contracts.IRepository;

namespace WMS.Contracts.IRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}
