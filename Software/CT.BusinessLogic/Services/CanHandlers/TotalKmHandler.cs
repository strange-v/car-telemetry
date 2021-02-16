using CT.BusinessLogic.Entities;
using System;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class TotalKmHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x03 && canMessage.Byte2 == 0x22)
            {
                var totalKm = (Convert.ToInt32((canMessage.Byte4.ToString("X") + canMessage.Byte5.ToString("X")), 16)) * 10;
                DataDictionary.aData[CanProperties.TotalKm] = totalKm.ToString();

                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
