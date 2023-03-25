using GMC.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMC.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;
        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
            
        }
        public async Task<User> CreateUserAsync(User user)
        {
            dataContext.User.Add(user);
            await dataContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return await dataContext.User.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {

            var userToRemove = await dataContext.User.FindAsync(userId);
            dataContext.User.Remove(userToRemove);
            return await dataContext.SaveChangesAsync() > 0;
        }

        public Task<User> GetUserAsync(int userId)
        {
            return this.dataContext.User.FindAsync(userId).AsTask();
        }

        public User GetUser(int userId)
        {
            return this.dataContext.User.Find(userId);
        }

        public List<User> GetUsers()
        {
            var users = dataContext.User.ToList();
            return users;
        }

        public Task<List<User>> GetUsersAsync()
        {

            var users = dataContext.User.ToListAsync();
            return users;
        }

        public async  Task<User> UpdateUserAsync(User user)
        {

            dataContext.User.Update(user);
            await dataContext.SaveChangesAsync();
            return user;
        }
    }
}
