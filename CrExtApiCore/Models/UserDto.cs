using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class UserDto
    {
      
        //public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Provide Email Address")]
        public string Email { get; set; }

        //public bool EmailConfirmed { get; set; }

        [Required(ErrorMessage = "Provide Password")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
        //public bool PhoneConfirmed { get; set; }

    }
}
