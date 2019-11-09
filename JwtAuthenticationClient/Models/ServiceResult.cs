using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationClient.Models
{
    public class ServiceResult<T>
    {
        public string StatusCode { get; set; }
        public T Result { get; set; }
    }
}
