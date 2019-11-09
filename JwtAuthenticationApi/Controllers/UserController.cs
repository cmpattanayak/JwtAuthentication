using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtAuthenticationApi.Data;
using JwtAuthenticationApi.Models;
using JwtAuthenticationApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.Configuration = configuration;
        }

        public ActionResult Index()
        {
            return Content("Api is running successfully!");
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(User user)
        {
            try
            {
                userRepository.CreateUser(user);
                return new JsonResult(new { StatusCode = "OK" });
            }
            catch(Exception ex)
            {
                return new JsonResult(new { StatusCode = "Error" });
            }
        }

        [Route("Login")]
        public ActionResult ValidateUser(string userName, string password)
        {
            try
            {
                var user = userRepository.GetUser(userName);
                if (user != null && user.Password.Equals(password, StringComparison.CurrentCulture))
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("SecurityKey")));


                    var tkn = new JwtSecurityToken(
                            issuer: "http://cpdev.com",
                            audience: "http://cpdev.com",
                            expires: DateTime.Now.AddHours(1),
                            claims: claims,
                            signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                            );

                    var token = new Token
                    {
                        TokenValue = new JwtSecurityTokenHandler().WriteToken(tkn),
                        Expires = tkn.ValidTo
                    };

                    return new JsonResult(new { StatusCode = "OK", Result = token });
                }
                else
                {
                    return new JsonResult(new { StatusCode = "Error" });
                }
            }
            catch(Exception ex)
            {
                return new JsonResult(new { StatusCode = "Error" });
            }
        }
    }
}