using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace CrExtApiCore.Models
{
    public class PackageRoleDto
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        [Required (ErrorMessage = "Name is Required")]  
        public int PRoleId { get; set; }
        public string RoleName { get; set; }

    }
}
