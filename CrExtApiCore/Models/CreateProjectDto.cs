using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class CreateProjectDto
    {

        [Required]
        public string Name { get; set; }

        [StringLength(400)]
        [Required]
        public string Description { get; set; }

        [Required]
        public int OrganisationId { get; set; }
    }
}
