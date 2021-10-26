using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControl.Model
{
    public class Pedal : Product
    {
        public Effect_Types PedalEffectType { get; set; }
        public string Pedal_Description { get; set; }
    }
}
