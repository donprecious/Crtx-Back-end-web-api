using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class Packages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(400)]
        public string Description{ get; set; }

        public virtual ICollection<Organisations> Organisations { get; set; }

        public virtual ICollection<PackagePRoles> PackagePRoles { get; set; }
    }
}
