﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempUtils.Model
{
    public class Pedal : Product
    {
        public Pedal()
        {
            ProductType = Product_Types.Pedal;
        }
      
        public override Product_Types ProductType { get;  }

        override public void Display()
        {
            Console.WriteLine($"Type Of Product : {ProductType}");
            Console.WriteLine("Pedal Display");
        }

    }
}