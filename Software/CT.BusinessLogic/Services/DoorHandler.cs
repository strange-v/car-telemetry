using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
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
                int[] doors = new int[4];
                string showByteInString = Convert.ToString(canMessage.Byte4, 2).PadLeft(8, '0');
                //01010101
                int[] door_index = AllIndexesOf(showByteInString, "1");


                if (Array.IndexOf(door_index, 7) == -1)
                {
                    // "Driver door is open!";
                    doors[0] = 1;
                }
                else
                {
                    // "Driver door is closed!";
                    doors[0] = 0;
                };
                if (Array.IndexOf(door_index, 5) == -1)
                {
                    // "Passanger door is open!";
                    doors[3] = 1;
                }
                else
                {
                    // "Passanger door is closed!";
                    doors[3] = 0;
                };
                if (Array.IndexOf(door_index, 3) == -1)
                {
                    // "Left Back door is open!";
                    doors[1] = 1;
                }
                else
                {
                    // "Left Back door is closed!";
                    doors[1] = 0;
                };

                if (Array.IndexOf(door_index, 1) == -1)
                {
                    // "Right Back door is open!";
                    doors[2] = 1;
                }
                else
                {
                    // "Right Back door is closed!";
                    doors[2] = 0;
                };

                
                return doors; 
                //tuple(YourEnum, string)

            }           
            else
            {
                return base.Handle(canMessage);
            }
        }
    }
}
