using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class Projects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(400)]
        public string Description{ get; set; }

        public int OrganisationId { get; set; }

        public Organisations Organisation { get; set; }

        public ICollection<Teams> Teams { get; set; }
       
    }
}
