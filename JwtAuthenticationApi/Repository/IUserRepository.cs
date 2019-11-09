using JwtAuthenticationApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationApi.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUser(string userName);

        void CreateUser(User user);
    }
}
