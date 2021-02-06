using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services
{
    class DoorHandler : AbstractHandler
    {
        public override object Handle(CanMessage canMessage)
        {
            //чисто для перевірки що сюди доходить
            Debug.WriteLine(canMessage);
            if (canMessage.Id == 0x0F68)
            {
                return $"Monkey: I'll eat the {canMessage.ToString()}.\n";
            }
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
