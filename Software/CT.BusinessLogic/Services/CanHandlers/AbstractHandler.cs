using System;
using System.Collections.Generic;
using System.Text;
using CT.BusinessLogic.Interfaces;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual CanMessage Handle(CanMessage canMessage)
        {
            
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(canMessage);
            }
            else
            {
                return null;
            }
            
        }
    }
}
