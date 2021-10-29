using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl.Model
{
    public class InventoryItem
    {
        public int InventoryItemID { get; set; }
        public int InventoryItemProductID { get; set; }
        public int InentoryItemQuantity { get; set; }
        public double InventoryItemSpecialPrice { get; set; }
    }
}
