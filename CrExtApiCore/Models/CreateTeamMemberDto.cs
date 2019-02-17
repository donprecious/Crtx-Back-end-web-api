using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CrExtApiCore.Models
{
    public class CreateTeamMemberDto
    {
      
        [Required]
        public string UserId { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public int TeamId { get; set; }

        [Required]
        public int ProjectId { get; set; }


    }
}
