using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class TurnSignalsHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x1B && canMessage.Byte2 == 0x22)
            {
                var turnSignal = (canMessage.Byte4 == 0x81) ? "Right" :
                                 (canMessage.Byte4 == 0x84) ? "Left" : 
                                 "0";

                DataDictionary.aData[CanProperties.TurnSignal] = turnSignal;
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
