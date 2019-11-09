using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JwtAuthenticationClient.Models;
using JwtAuthenticationClient.Filters;
using JwtAuthenticationClient.Services;

namespace JwtAuthenticationClient.Controllers
{
    [Authenticate]
    public class HomeController : Controller
    {
        private readonly IService service;

        private string GetToken()
        {
            return Request != null ? Request.Cookies["auth-cookie"] : "";
        }
        public HomeController(IService service)
        {
            this.service = service;           
        }

        public IActionResult Index()
        {
            var res = service.Sum(5, 6, GetToken());
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
