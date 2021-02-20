using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using CT.BusinessLogic.Interfaces;
using CT.BusinessLogic.Entities;
using System.Text.RegularExpressions;


namespace CT.Web.Pages
{
    public class IndexModel : ComponentBase
    {
        [Inject] ISerialService SerialService { get; set; }
        [Inject] ICanMessageComposer CanMessageComposer { get; set; }
        [Inject] IHandler Handler { get; set; }
        [Inject] ISerialService Notifier { get; set; }
        public string styleDoorDriver { get; set; } = "";
        public string styleDoorPassenger { get; set; } = "";
        public string styleDoorBackLeft { get; set; } = "";
        public string styleDoorBackRight { get; set; } = "";
        public string indoorTemperature { get; set; } = "";
        public string outdoorTemperature { get; set; } = "";
        public string turnSignal { get; set; } = "";
        public string handbrake { get; set; } = "";
        public string coolantTemp { get; set; } = "";
        public string engineRpm { get; set; } = "";
        public string fuelLevel { get; set; } = "";
        public string currFuel { get; set; } = "";
        public string oilTemp { get; set; } = "";
        public string totalKm { get; set; } = "";

        public string message { get; set; } = "";
        public string canCommand { get; set; } = "";

        protected override async Task OnInitializedAsync()
        {
            var r = new Regex(@".{3}\s.{2}\s.{2}\s.{2}\s.{2}\s.{2}\s.{2}\s.{2}\s.{2}\s*");
            Notifier.Notify += GetValue;
            try
            {
                await Task.Delay(300);
                canCommand = await SerialService.GetSerialValue();

                if (r.IsMatch(canCommand))
                {
                    await InvokeAsync(GetValue);
                    var can_message = CanMessageComposer.Compose(canCommand);
                    var result = Handler.Handle(can_message);
                }
            }
            catch (System.ArgumentNullException)
            {
                message = "Something wrong with selected COM port";
            }
            catch (System.NullReferenceException)
            {
                message = "Something wrong with selected COM port";
            }
        }

        public async Task GetValue()
        {
            canCommand = await SerialService.GetSerialValue();
            var can_message = CanMessageComposer.Compose(canCommand);
            var result = Handler.Handle(can_message);
            styleDoorDriver = DataDictionary.aData[CanProperties.DoorFrontLeft] + "_left_animation";
            styleDoorBackLeft = DataDictionary.aData[CanProperties.DoorBackLeft] + "_left_animation";
            styleDoorBackRight = DataDictionary.aData[CanProperties.DoorBackRight] + "_right_animation";
            styleDoorPassenger = DataDictionary.aData[CanProperties.DoorFrontRight] + "_right_animation";
            turnSignal = DataDictionary.aData[CanProperties.TurnSignal];
            indoorTemperature = DataDictionary.aData[CanProperties.IndoorTemperature];
            outdoorTemperature = DataDictionary.aData[CanProperties.OutdoorTemperature];
            handbrake = DataDictionary.aData[CanProperties.Handbrake];
            coolantTemp = DataDictionary.aData[CanProperties.CoolantTemperature];
            fuelLevel = DataDictionary.aData[CanProperties.FuelLevel];
            currFuel = DataDictionary.aData[CanProperties.CurrentFuelConsumption];
            engineRpm = DataDictionary.aData[CanProperties.EngineRpm];
            oilTemp = DataDictionary.aData[CanProperties.OilTemperature];
            totalKm = DataDictionary.aData[CanProperties.TotalKm];
            await InvokeAsync(() => StateHasChanged());
        }
    }
}

