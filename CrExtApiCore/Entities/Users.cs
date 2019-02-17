using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
   [NotMapped]
    public class Users : IdentityUser
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName{ get; set; }

        /*       public ICollection<Roles> Roles{ get; set; */
    }
   
    
}
