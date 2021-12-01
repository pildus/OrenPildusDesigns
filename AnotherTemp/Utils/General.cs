using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataControl.Model;

// This class is a gernral maintanance of global data and objects
namespace DataControl.Utils
{
    
    // Define Product types
    public  enum ProductTypes
    {
        Pedal, Board, Component
      
    }

    // Define Effectct types
    public enum EffectTypes
    {
        Boost, Overdrive, Distortion, Chorus, Delay, Tremolo, Phaser,Misc,Fuzz
    }

    // Define Component types
    public enum ComponentTypes
    {
        Resistor,Capacitor,PolCapacitor,IC,Potentiometer,LED,Diode,Switch
    }

    // Global constants to be used in the solution
    public class Constants
    {
        public static User SessionUser = new User();
        public const int _passMinLength = 8;
        public const int _passMaxLength = 20;
        public const string _specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
    }


}
