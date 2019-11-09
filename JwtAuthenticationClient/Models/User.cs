using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthenticationClient.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name ="User Name")]
        [Required(ErrorMessage ="Please provide user name")]
        public string UserName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        public string Password { get; set; }
    }
}
