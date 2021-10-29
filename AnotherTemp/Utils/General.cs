using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataControl.Model;

namespace DataControl.Utils
{
    
    public  enum ProductTypes
    {
        Pedal, Board, Kit, Component
    }

    public enum EffectTypes
    {
        Boost, Overdrive, Distortion, Chorus, Delay, Tremolo, Phaser,Misc
    }

    public enum ComponentTypes
    {
        Resistor,Capacitor,PolCapacitor,IC,Potentiometer,LED,Diode
    }
    public class Constants
    {
        public static User SessionUser = new User();
        public const int _passMinLength = 8;
        public const int _passMaxLength = 20;
        public const string _specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
    }


}
