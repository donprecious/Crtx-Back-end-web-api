using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrExtApiCore.Models
{
    public class LoginDto
    {
        [EmailAddress]
        [Required (ErrorMessage = "Provide Email Address")]
        public string Email { get; set; }

        
        [Required (ErrorMessage = "Provide Password")]
        public string Password { get; set; }

    }
}
