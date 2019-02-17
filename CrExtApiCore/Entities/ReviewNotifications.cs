using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ReviewNotifications
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ReviewKindId")]
        public int ReviewKindId { get; set; }
        public ReviewKinds ReviewKind { get; set; }

        [ForeignKey("ReviewId")]
        public int ReviewId { get; set; }
        public Reviews Review { get; set; }

        [ForeignKey("ReviewActionId")]
        public int ReviewActionId { get; set; }
        public ReviewActions ReviewAction { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
     
        public DateTime DateAdded { get; set; }

       
    }
}
