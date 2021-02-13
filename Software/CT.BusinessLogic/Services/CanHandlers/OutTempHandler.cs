using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    class OutTempHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {

            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x0C && canMessage.Byte2 == 0x22)
            {
                var outdoorTemperature = (double)(canMessage.Byte4 - 100)/2;
                DataDictionary.aData[CanProperties.OutdoorTemperature] = outdoorTemperature.ToString();
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
