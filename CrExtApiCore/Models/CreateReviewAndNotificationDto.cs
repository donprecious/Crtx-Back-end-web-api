using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CrExtApiCore.Models
{
    public class CreateReviewAndNotitficationDto
    {
        public CreateReviewDto review { get; set; }
        public CreateReviewNotificationsDto reviewNotification { get; set; }
    }
}
