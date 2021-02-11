using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services
{
    public class InTempHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            
            if (canMessage.Id.ToString("X") == "7B0" && canMessage.Byte3.ToString("X") == "13" && canMessage.Byte2.ToString("X") == "26")
            {
                Debug.WriteLine('\n' + "InTEMP" + '\n');

                return canMessage;
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
