using CT.BusinessLogic.Interfaces;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public virtual CanMessage Handle(CanMessage inCanMessage)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(inCanMessage);
            }
            else
            {
                return null;
            }
        }
    }
}