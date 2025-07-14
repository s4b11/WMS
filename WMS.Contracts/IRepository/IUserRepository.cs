using WMS.Models;

namespace WMS.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}
