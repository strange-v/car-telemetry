using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class CurrFuelConsumptionHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            var nextHandler = new TotalKmHandler();

            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x98 && canMessage.Byte2 == 0x22)
            {
                var currFuelConsumption = (double)canMessage.Byte5 / 10;
                DataDictionary.aData[CanProperties.CurrentFuelConsumption] = currFuelConsumption.ToString();

                return canMessage;
            }
            else
            {
                SetNext(nextHandler);
                return base.Handle(canMessage);
            }
        }
    }
}
