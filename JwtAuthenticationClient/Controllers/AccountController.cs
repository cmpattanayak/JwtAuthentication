using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthenticationClient.Models;
using JwtAuthenticationClient.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService service;

        public AccountController(IService service)
        {
            this.service = service;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            service.CreateUser(user);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var token = service.Login(user);

            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("Password", user.Password);

            Response.Cookies.Append("auth-cookie", token.Result.TokenValue,
                    new CookieOptions { Expires = token.Result.Expires, HttpOnly = true });

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("auth-cookie");
            return RedirectToAction("Login", "Account");
        }
    }
}