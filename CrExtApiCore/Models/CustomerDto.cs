using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string OtherName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Sex { get; set; }

        public string CustomData { get; set; }

        public int TeamId { get; set; }
        public Teams Team { get; set; }

        public ICollection<Reviews> Reviews { get; set; }
    }
}
