using CT.BusinessLogic.Entities;
using System;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class EngineRpmHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x0C && canMessage.Byte2 == 0xF4)
            {
                var engineRpm = (Convert.ToInt32((canMessage.Byte4.ToString("X") + canMessage.Byte5.ToString("X")), 16)) / 4;
                DataDictionary.aData[CanProperties.EngineRpm] = engineRpm.ToString();
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
