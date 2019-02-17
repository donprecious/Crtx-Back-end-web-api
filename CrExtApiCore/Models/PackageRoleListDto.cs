using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace CrExtApiCore.Models
{
    public class PackageRoleListDto
    {
      
        public Packages Package { get; set; }
       
        public IEnumerable<PRole> PRole { get; set; }
                                                                                                                                                                                            
    }
}
