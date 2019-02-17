using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class TeamMemberDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Users User { get; set; }
        public String Description { get; set; }

        public int TeamId { get; set; }

        public ICollection<Teams> Teams { get; set; }

        public int ProjectId { get; set; }

        public Projects Projects { get; set; }

    }
}
