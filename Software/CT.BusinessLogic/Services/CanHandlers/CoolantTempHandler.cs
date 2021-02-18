using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class CoolantTempHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x05 && canMessage.Byte2 == 0xF4)
            {
                var coolantTemp = canMessage.Byte4 - 40;
                DataDictionary.aData[CanProperties.CoolantTemperature] = coolantTemp.ToString();
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
