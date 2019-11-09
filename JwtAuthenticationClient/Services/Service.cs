using JwtAuthenticationClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace JwtAuthenticationClient.Services
{
    public class Service : IService
    {
        public ServiceResult<int> Sum(int a, int b, string token)
        {
            string path = string.Format("http://localhost:54893/api/calculator/sum?a={0}&b={1}", a, b);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(path).Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResult<int>>(response.Result);

            return result;
        }

        public void CreateUser(User user)
        {
            string path = "http://localhost:54893/api/user/register";
            HttpClient client = new HttpClient();
            client.PostAsJsonAsync<User>(path, user);
        }

        public ServiceResult<Jwt> Login(User user)
        {
            string path = string.Format("http://localhost:54893/api/user/login?userName={0}&password={1}", user.UserName, user.Password);
            HttpClient client = new HttpClient();
            var response = client.GetAsync(path).Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResult<Jwt>>(response.Result);

            return result;
        }
    }
}