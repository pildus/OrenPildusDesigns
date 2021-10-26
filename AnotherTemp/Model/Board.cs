using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl.Model
{
    public class Board : Product
    {
        public Effect_Types BoardEffectType { get; set; }
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }

    }
}
