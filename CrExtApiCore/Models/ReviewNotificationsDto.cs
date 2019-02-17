using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrExtApiCore.Models
{
    public class ReviewNotificationsDto
    {
      
        public int Id { get; set; }

        public int ReviewKindId { get; set; }

        public int ReviewId { get; set; }

        public int ReviewActionId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }


        public DateTime DateAdded { get; set; }

       
    }
}
