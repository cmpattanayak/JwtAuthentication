using JwtAuthenticationClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationClient.Services
{
    public interface IService
    {
        ServiceResult<int> Sum(int a, int b, string token);
        void CreateUser(User user);
        ServiceResult<Jwt> Login(User user);
    }
}
