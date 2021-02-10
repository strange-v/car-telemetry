using CT.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CT.BusinessLogic.Interfaces
{
    public interface ICanMessageComposer
    {
        CanMessage Compose(string rawMessage);
    }
}