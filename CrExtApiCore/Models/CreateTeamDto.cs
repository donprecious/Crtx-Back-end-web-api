using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrExtApiCore.Models
{
    public class CreateTeamDto
    {
  
        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }
     
    }
}
