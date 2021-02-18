using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class HandbrakeHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x05 && canMessage.Byte2 == 0x22)
            {
                var handbrake = canMessage.Byte4.ToString("X");
                DataDictionary.aData[CanProperties.Handbrake] = handbrake[1].ToString();
                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
