using System;
using System.Collections.Generic;
using System.Text;

namespace CT.BusinessLogic.Entities
{
    public class DataDictionary
    {
        
        public static Dictionary<CanProperties, string> aData = new Dictionary<CanProperties, string>
        {
            { CanProperties.DoorBackLeft, "Close"},
            { CanProperties.DoorBackRight, "Close"},
            { CanProperties.DoorFrontLeft, "Close"},
            { CanProperties.DoorFrontRight, "Close"},
            { CanProperties.OutdoorTemperature, "0.0"},
            { CanProperties.IndoorTemperature, "0.0"}
        };
        
    }

}
