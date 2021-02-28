using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Interfaces
{
    public interface ICanMessageComposer
    {
        CanMessage Compose(string rawMessage);
    }
}