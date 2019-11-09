using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalculatorController : ControllerBase
    {
        [Route("Sum")]
        public ActionResult Sum(int a, int b)
        {
            var c = a + b;
            return new JsonResult(new { StatusCode = "OK", Result = c });
        }

        [Route("Difference")]
        public ActionResult Subtract(int a, int b)
        {
            var c = a - b;
            return new JsonResult(new { StatusCode = "OK", Result = c });
        }

        [Route("Multiply")]
        public ActionResult Multiply(int a, int b)
        {
            var c = a * b;
            return new JsonResult(new { StatusCode = "OK", Result = c });
        }

        [Route("Division")]
        public ActionResult Division(int a, int b)
        {
            var c = a / b;
            return new JsonResult(new { StatusCode = "OK", Result = c });
        }
    }
}