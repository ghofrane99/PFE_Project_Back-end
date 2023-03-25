using GMC.Core;
using GMC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User> CreateUserAsync(User user)
        {
            return userRepository.CreateUserAsync(user);
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            return userRepository.DeleteUserAsync(userId);
        }

        public User GetUser(int userId)
        {
          return userRepository.GetUser(userId);
        }

        public Task<User> GetUserAsync(int userId)
        {
            return userRepository.GetUserAsync(userId);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return userRepository.GetUsersAsync();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            return userRepository.UpdateUserAsync(user);
        }
        public async Task<User> Authenticate(User userv)
        {
            return await userRepository.GetByUsernameAndPassword(userv.Username, userv.Password);
        }
    }
}
