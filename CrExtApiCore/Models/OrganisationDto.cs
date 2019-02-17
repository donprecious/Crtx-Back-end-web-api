using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace CrExtApiCore.Models
{
    public class OrganisationDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Provide Organisation name")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Provide Description of organisation")]
        [StringLength(400)]
        public string Description { get; set; }
        public string RCNumber { get; set; }
        public string NatureOfBusiness { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessAddress { get; set; }

        [Required(ErrorMessage = "Provide Associated User id")]
        public string UserId { get; set; }
        public Users User { get; set; }

        [Required(ErrorMessage = "Specify the a package for this organisation")]
        public int PackageId { get; set; }
        public Packages Package { get; set; }

    }
}
