using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataControl.Utils;

namespace DataControl.Model
{
    [Table("Components")]
    public class Component : Product
    {
        [Required]
        public int QuantityPerLot { get; set; }
        
        
        public ComponentTypes ComponentType { get; set; }
    }
}
