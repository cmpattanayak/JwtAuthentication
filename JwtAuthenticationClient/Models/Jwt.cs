using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwtAuthenticationClient.Models
{
    public class Jwt
    {
        public string TokenValue { get; set; }

        public DateTime Expires { get; set; }
    }
}