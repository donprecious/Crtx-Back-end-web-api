using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class CreateUserDto
    {
      
       

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Provide Email Address")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Provide Password")]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }
        
    }
}
