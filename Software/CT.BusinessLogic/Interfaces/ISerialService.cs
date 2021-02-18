using System;
using System.Threading.Tasks;

namespace CT.BusinessLogic.Interfaces
{
    public interface ISerialService
    {
        Task<string> GetSerialValue();
        event Func<Task> Notify;
    }
}