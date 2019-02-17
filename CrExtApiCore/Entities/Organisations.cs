using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class Organisations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string RCNumber { get; set; }
        public string NatureOfBusiness { get; set; } 
        public string PhoneNumber { get; set; }
        public string BusinessAddress { get; set; }


        [StringLength(400)]
        public string Description{ get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }

        public int PackageId { get; set; }
        public Packages Package { get; set; }
        public ICollection<Projects> Projects { get; set; }
    }
}

