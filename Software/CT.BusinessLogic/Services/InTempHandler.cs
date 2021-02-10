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
                //7B0 05 62 26 13 00 5B AA AA - 9.1, 91 == 0x5B
                //7B0 05 62 26 13 00 5C AA AA - 9.2°С
                //7B0 05 62 26 13 00 5D AA AA -9.3°С

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
