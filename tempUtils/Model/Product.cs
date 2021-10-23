using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempUtils.Model
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        public ProductType ProductType { get; set; }

        public void ProductDisplay()
        {

        }

    }
}
