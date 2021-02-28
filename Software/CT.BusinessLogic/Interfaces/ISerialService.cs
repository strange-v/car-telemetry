using System;
using System.Threading.Tasks;

namespace CT.BusinessLogic.Interfaces
{
    public interface ISerialService
    {
        event Func<string, Task> Notify;
    }
}