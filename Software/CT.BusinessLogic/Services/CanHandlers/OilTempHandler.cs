using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class OilTempHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x2F && canMessage.Byte2 == 0x20)
            {
                var oilTemp = canMessage.Byte4 - 58;
                DataDictionary.aData[CanProperties.OilTemperature] = oilTemp.ToString();
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
