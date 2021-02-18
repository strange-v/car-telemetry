using Microsoft.AspNetCore.Components;

namespace CT.Web.Pages
{
    public class IndexModel : ComponentBase
    {
        public string styleDoorDriver { get; set; } = "";
        public string styleDoorPassenger { get; set; } = "";
        public string styleDoorBackLeft { get; set; } = "";
        public string styleDoorBackRight { get; set; } = "";
        public string turnSignal { get; set; } = "";
        public string handbrake { get; set; } = "";
        public string coolantTemp { get; set; } = "";
        public string engineRpm { get; set; } = "";
        public string fuelLevel { get; set; } = "";
        public string currFuel { get; set; } = "";
        public string oilTemp { get; set; } = "";
        public string totalKm { get; set; } = ""; 
    }
}

