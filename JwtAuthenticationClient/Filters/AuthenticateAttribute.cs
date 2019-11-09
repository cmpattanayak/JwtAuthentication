using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationClient.Filters
{
    public class AuthenticateAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cookie = context.HttpContext.Request.Cookies["auth-cookie"];
            if (string.IsNullOrWhiteSpace(cookie))
                context.Result = new RedirectToActionResult("Login", "Account", "returnUrl");
        }
    }
}
