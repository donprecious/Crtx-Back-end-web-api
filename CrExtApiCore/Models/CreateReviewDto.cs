using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrExtApiCore.Models
{
    public class CreateReviewDto
    {
        [Required]
        public int TeamMemberId { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public string Comment { get; set; }
    }
}
