using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataControl.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int OrderQuantity { get; set; }

        [Required]
        public double OrderTotalAmount { get; set; }

        [ForeignKey("Users")]
        public int OrderUserID { get; set; }
        public User User { get; set; }

        [ForeignKey("Inventory")]
        public int OrderInventoryItemID { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public bool OrderIsConfirmed { get; set; } = false;

    }
}