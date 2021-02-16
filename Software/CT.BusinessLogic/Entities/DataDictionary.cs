using System.Collections.Generic;

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
            { CanProperties.IndoorTemperature, "0.0"},
            { CanProperties.Handbrake, "0"},
            { CanProperties.FuelLevel, "0"},
            { CanProperties.CoolantTemperature, "0"},
            { CanProperties.EngineRpm, "0"},
            { CanProperties.OilTemperature, "0"},
            { CanProperties.TurnSignal, "0"},
            { CanProperties.CurrentFuelConsumption, "0.0"},
            { CanProperties.TotalKm, "0"}
        };
        
    }

}
