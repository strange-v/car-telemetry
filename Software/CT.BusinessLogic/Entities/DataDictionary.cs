using System;
using System.Collections.Generic;
using System.Text;

namespace CT.BusinessLogic.Entities
{
    public class DataDictionary
    {
        
        public static Dictionary<DataEnum.CAN_properties, string> aData = new Dictionary<DataEnum.CAN_properties, string>
        {
            { DataEnum.CAN_properties.DoorBackLeft, "Close"},
            { DataEnum.CAN_properties.DoorBackRight, "Close"},
            { DataEnum.CAN_properties.DoorFrontLeft, "Close"},
            { DataEnum.CAN_properties.DoorFrontRight, "Close"},
            { DataEnum.CAN_properties.OutdoorTemperature, "0.0"},
            { DataEnum.CAN_properties.IndoorTemperature, "0.0"}
        };
        
    }

}
