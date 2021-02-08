using System;
using System.Collections.Generic;
using System.Text;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Interfaces
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        CanMessage Handle(CanMessage canMessage);
    }
}
