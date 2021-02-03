using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace car_telemetry.Data
{
    public class CANanalys
    {
        //дані будуть йти в форматі CAN пакетів через серіал: 
        //"0x0F6 8 0x8E 0x87 0x32 0xFA 0x26 0x8E 0xBE 0x86"
        //перші два байти буде id, наступний байт кількість даних, далі до 8 байтів даних
        //в кінці кожного такого повідомлення буде закінчення символ нового рядка
        public void Analyse(var string in, var string out)
        {

        }
    }
}
