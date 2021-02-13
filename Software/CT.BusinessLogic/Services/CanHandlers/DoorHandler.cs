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
            var nextHandler = new InTempHandler();
            
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x0D && canMessage.Byte2 == 0x22)
            {
                string showByteInString = Convert.ToString(canMessage.Byte4, 2).PadLeft(8, '0');
                int[] door_index = AllIndexesOf(showByteInString, "1");


                if (Array.IndexOf(door_index, 7) == -1)
                {
                    DataDictionary.aData[CanProperties.DoorFrontLeft] = "Open";
                }
                else
                {
                    DataDictionary.aData[CanProperties.DoorFrontLeft] = "Close";
                };
                if (Array.IndexOf(door_index, 5) == -1)
                {
                    DataDictionary.aData[CanProperties.DoorFrontRight] = "Open";
                }
                else
                {
                    DataDictionary.aData[CanProperties.DoorFrontRight] = "Close";
                };
                if (Array.IndexOf(door_index, 3) == -1)
                {
                    DataDictionary.aData[CanProperties.DoorBackLeft] = "Open";
                }
                else
                {
                    DataDictionary.aData[CanProperties.DoorBackLeft] = "Close";
                };

                if (Array.IndexOf(door_index, 1) == -1)
                {
                    DataDictionary.aData[CanProperties.DoorBackRight] = "Open";
                }
                else
                {
                    DataDictionary.aData[CanProperties.DoorBackRight] = "Close";
                };

                
                return canMessage;
                
            }           
            else
            {
                SetNext(nextHandler);
                return base.Handle(canMessage);
            }
        }
    }
}
