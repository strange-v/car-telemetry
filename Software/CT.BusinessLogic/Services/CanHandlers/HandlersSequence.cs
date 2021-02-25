using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class HandlersSequence : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            var door = new DoorHandler();
            var inTemp = new InTempHandler();
            var outTemp = new OutTempHandler();
            var handbrake = new HandbrakeHandler();
            var fuelLevel = new FuelLevelHandler();
            var coolantTemp = new CoolantTempHandler();
            var engineRpm = new EngineRpmHandler();
            var oilTemp = new OilTempHandler();
            var turnSignals = new TurnSignalsHandler();
            var currFuelConsumption = new CurrFuelConsumptionHandler();
            var totalKm = new TotalKmHandler();

            door.SetNext(inTemp);
            inTemp.SetNext(outTemp);
            outTemp.SetNext(handbrake);
            handbrake.SetNext(fuelLevel);
            fuelLevel.SetNext(coolantTemp);
            coolantTemp.SetNext(engineRpm);
            engineRpm.SetNext(oilTemp);
            oilTemp.SetNext(turnSignals);
            turnSignals.SetNext(currFuelConsumption);
            currFuelConsumption.SetNext(totalKm);

            door.Handle(canMessage);

            return base.Handle(canMessage);
        }
    }
}
