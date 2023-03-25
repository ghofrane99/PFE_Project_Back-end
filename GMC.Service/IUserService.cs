using GMC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GMC.Service
{
    public interface IUserService
    {
        User GetUser(int userId);
        Task<User> GetUserAsync(int userId);
        List<User> GetUsers();
        Task<List<User>> GetUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User> Authenticate(User userv);
    }
}
