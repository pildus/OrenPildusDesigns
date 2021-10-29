﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataControl.Utils;

namespace DataControl.Model
{
    public class Board : Product
    {
        [Required]
            public double BoardWidth { get; set; }

        [Required]
        public double BoardHeight { get; set; }
    }
}
