using CT.BusinessLogic.Entities;
using CT.BusinessLogic.Interfaces;
using System.Globalization;

namespace CT.BusinessLogic.Services
{
    public class CanMessageComposer : ICanMessageComposer
    {
        public CanMessage Compose(string rawMessage)
        {
            var data = rawMessage.Split(' ');
            return new CanMessage
            {
                Id = int.Parse(data[0], NumberStyles.HexNumber),
                Byte0 = byte.Parse(data[1], NumberStyles.HexNumber),
                Byte1 = byte.Parse(data[2], NumberStyles.HexNumber),
                Byte2 = byte.Parse(data[3], NumberStyles.HexNumber),
                Byte3 = byte.Parse(data[4], NumberStyles.HexNumber),
                Byte4 = byte.Parse(data[5], NumberStyles.HexNumber),
                Byte5 = byte.Parse(data[6], NumberStyles.HexNumber),
                Byte6 = byte.Parse(data[7], NumberStyles.HexNumber),
                Byte7 = byte.Parse(data[8], NumberStyles.HexNumber)
            };
        }
    }
}
