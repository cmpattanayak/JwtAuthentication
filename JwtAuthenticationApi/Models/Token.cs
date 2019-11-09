using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationApi.Models
{
    public class Token
    {
        public string TokenValue { get; set; }
        public DateTime Expires { get; set; }
    }
}
