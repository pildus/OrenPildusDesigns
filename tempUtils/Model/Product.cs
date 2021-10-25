using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempUtils.Model
{
    public abstract class Product
    {
        private Product_Types _productType;
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public abstract Product_Types ProductType { get; }
        public abstract  void Display();

    }

    public enum Product_Types
    {
        Pedal,Board,Kit,Component
    }



}
