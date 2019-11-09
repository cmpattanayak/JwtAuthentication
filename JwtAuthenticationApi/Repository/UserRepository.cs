using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthenticationApi.Data;

namespace JwtAuthenticationApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext context;

        public UserRepository(UserDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetUser(string userName)
        {
            return context.Users.FirstOrDefault(p=>p.UserName.Equals(userName));
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }
    }
}
