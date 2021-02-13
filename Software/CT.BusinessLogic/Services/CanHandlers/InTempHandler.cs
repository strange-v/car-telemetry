using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class InTempHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            var nextHandler = new OutTempHandler();
            if (canMessage.Id == 0x7B0 && canMessage.Byte3 == 0x13 && canMessage.Byte2 == 0x26)
            {
                var indoorTemperature = canMessage.Byte5 - 40;
                DataDictionary.aData[CanProperties.IndoorTemperature] = indoorTemperature.ToString();
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
