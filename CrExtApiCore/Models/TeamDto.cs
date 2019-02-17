using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TeamMembers> TeamMembers { get; set; }
        public int ProjectId { get; set; }
     
    }
}
