using System;
using System.Collections.Generic;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services
{
    public class DoorHandler : AbstractHandler
    {
        public static int[] AllIndexesOf(string str, string substr, bool ignoreCase = false)
        {
            if (string.IsNullOrWhiteSpace(str) ||
                string.IsNullOrWhiteSpace(substr))
            {
                throw new ArgumentException("String or substring is not specified.");
            }

            var indexes = new List<int>();
            int index = 0;

            while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
            {
                indexes.Add(index++);
            }

            return indexes.ToArray();
        }
        public override CanMessage Handle(CanMessage canMessage)
        {

            if (canMessage.Id.ToString("X") == "77E" && canMessage.Byte3.ToString("X") == "D" && canMessage.Byte2.ToString("X") == "22")
            {
                string showByteInString = Convert.ToString(canMessage.Byte4, 2).PadLeft(8, '0');
                //01010101
                int[] door_index = AllIndexesOf(showByteInString, "1");


                if (Array.IndexOf(door_index, 7) == -1)
                {
                    // "Driver door is open!";
                    Data.aData[Data.CAN_properties.DoorFrontLeft] = "Open";
                }
                else
                {
                    // "Driver door is closed!";
                    Data.aData[Data.CAN_properties.DoorFrontLeft] = "Close";
                };
                if (Array.IndexOf(door_index, 5) == -1)
                {
                    Data.aData[Data.CAN_properties.DoorFrontRight] = "Open";
                    // "Passanger door is open!";
                }
                else
                {
                    Data.aData[Data.CAN_properties.DoorFrontRight] = "Close";
                    // "Passanger door is closed!";
                };
                if (Array.IndexOf(door_index, 3) == -1)
                {
                    Data.aData[Data.CAN_properties.DoorBackLeft] = "Open";
                    // "Left Back door is open!";
                }
                else
                {
                    Data.aData[Data.CAN_properties.DoorBackLeft] = "Close";
                    // "Left Back door is closed!";
                };

                if (Array.IndexOf(door_index, 1) == -1)
                {
                    Data.aData[Data.CAN_properties.DoorBackRight] = "Open";
                    // "Right Back door is open!";
                }
                else
                {
                    Data.aData[Data.CAN_properties.DoorBackRight] = "Close";
                    // "Right Back door is closed!";
                };

               
                return canMessage;

            }           
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
