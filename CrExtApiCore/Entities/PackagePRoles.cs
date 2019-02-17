using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class PackagePRoles
    {
        public int PackageId { get; set; }
        public Packages Package { get; set; }

        public int PRoleId { get; set; }
        public PRole PRole { get; set; }
    }
}
