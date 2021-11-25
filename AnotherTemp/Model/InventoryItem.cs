using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataControl.Model
{
    [Table("Inventory")]
    public class InventoryItem
    {
        [Key]
        public int InventoryItemID { get; set; }
        
        [ForeignKey ("Product")]
        public int InventoryItemProductID { get; set; }
        public Product Product { get; set; }
        public int InentoryItemQuantity { get; set; }
        public double InventoryItemSpecialPrice { get; set; }
    }
}
