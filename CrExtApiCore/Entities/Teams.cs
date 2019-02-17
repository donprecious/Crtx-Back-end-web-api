using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class Teams
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description{ get; set; }


        public ICollection<TeamMembers> TeamMembers { get; set; }
       
        public int ProjectId { get; set; }
        public Projects Project { get; set; }
     
    }
}
