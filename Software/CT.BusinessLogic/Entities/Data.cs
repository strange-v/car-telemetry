using System;
using System.Collections.Generic;
using System.Text;

namespace CT.BusinessLogic.Entities
{
    public class Data
    {
        public enum CAN_properties
        {
            DoorFrontRight,
            DoorFrontLeft,
            DoorBackRight,
            DoorBackLeft,
            OutdoorTemperature,
            IndoorTemperature
        }
        public static Dictionary<CAN_properties, string> aData = new Dictionary<CAN_properties, string>()
        {
            { CAN_properties.DoorBackLeft, "Close"},
            { CAN_properties.DoorBackRight, "Close"},
            { CAN_properties.DoorFrontLeft, "Close"},
            { CAN_properties.DoorFrontRight, "Close"},
            { CAN_properties.OutdoorTemperature, "0.0"},
            { CAN_properties.IndoorTemperature, "0.0"}
        };
        
    }

}
