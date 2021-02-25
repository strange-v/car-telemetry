using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class CurrFuelConsumptionHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x98 && canMessage.Byte2 == 0x22)
            {
                var currFuelConsumption = (double)canMessage.Byte5 / 10;
                SetValue(CanProperties.CurrentFuelConsumption, currFuelConsumption.ToString());
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
