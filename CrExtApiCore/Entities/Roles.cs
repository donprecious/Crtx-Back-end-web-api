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
    public class Roles: IdentityRole
    {
       // [databasegenerated(databasegeneratedoption.identity)]
     

        [StringLength(400)]
        public string Description{ get; set; }
    
    }
}
