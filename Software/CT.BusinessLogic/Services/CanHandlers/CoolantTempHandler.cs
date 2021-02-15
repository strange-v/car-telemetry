using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class CoolantTempHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            var nextHandler = new EngineRpmHandler();

            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x05 && canMessage.Byte2 == 0xF4)
            {
                var coolantTemp = canMessage.Byte4 - 40;
                DataDictionary.aData[CanProperties.CoolantTemperature] = coolantTemp.ToString();
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
