using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class FuelLevelHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x06 && canMessage.Byte2 == 0x22)
            {
                var fuelLevel = canMessage.Byte4.ToString();
                SetValue(CanProperties.FuelLevel, fuelLevel);
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
