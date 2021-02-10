using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.BusinessLogic.Entities;
using CT.BusinessLogic.Interfaces;
using System.Globalization;

namespace CT.BusinessLogic.Services
{
    public class CanMessageComposer : ICanMessageComposer
    {
        //дані будуть йти в форматі CAN пакетів через серіал: 
        //"0x0F6 8 0x8E 0x87 0x32 0xFA 0x26 0x8E 0xBE 0x86\n"
        //такі будуьб приходити:
        //77E 05 62 22 0D 55 65 AA AA\n
        //77E 04 62 22 0C 68 AA AA AA\n - 2 = 104°С
        //перші два байти буде id, наступний байт кількість даних, далі до 8 байтів даних
        //в кінці кожного такого повідомлення буде закінчення символ нового рядка
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
