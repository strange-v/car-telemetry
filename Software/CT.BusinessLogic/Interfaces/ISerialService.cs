using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CT.BusinessLogic.Interfaces
{
    public interface ISerialService
    {
        Task<string> GetSerialValue();
    }
}