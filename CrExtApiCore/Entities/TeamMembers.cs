using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class TeamMembers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId{ get; set; }
        public ICollection<Users> User { get; set; }
        public String Description{ get; set; }

        public int TeamId { get; set; }

        public ICollection<Teams> Teams { get; set; }

        public int ProjectId { get; set; }

        public Projects Projects { get; set; }

        public ICollection<Reviews> Reviews { get; set; }

        

    }
}
