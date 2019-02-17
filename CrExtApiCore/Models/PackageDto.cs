using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace CrExtApiCore.Models
{
    public class PackageDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Name is Required")]
        [StringLength(400)]
        public string Description { get; set; }

    }
}
