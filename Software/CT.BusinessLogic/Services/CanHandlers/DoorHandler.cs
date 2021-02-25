using System;
using System.Collections.Generic;
using CT.BusinessLogic.Entities;

namespace CT.BusinessLogic.Services.CanHandlers
{
    public class DoorHandler : AbstractHandler
    {
        public override CanMessage Handle(CanMessage canMessage)
        {
            if (canMessage.Id == 0x77E && canMessage.Byte3 == 0x0D && canMessage.Byte2 == 0x22)
            {
                var showByteInString = Convert.ToString(canMessage.Byte4, 2).PadLeft(8, '0');
                var doorIndex = AllIndexesOf(showByteInString, "1");


                if (Array.IndexOf(doorIndex, 7) == -1)
                {
                    SetValue(CanProperties.DoorFrontLeft, "Open");
                }
                else
                {
                    SetValue(CanProperties.DoorFrontLeft, "Close");
                };
                if (Array.IndexOf(doorIndex, 5) == -1)
                {
                    SetValue(CanProperties.DoorFrontRight, "Open");
                }
                else
                {
                    SetValue(CanProperties.DoorFrontRight, "Close");
                };
                if (Array.IndexOf(doorIndex, 3) == -1)
                {
                    SetValue(CanProperties.DoorBackLeft, "Open");
                }
                else
                {
                    SetValue(CanProperties.DoorBackLeft, "Close");
                };

                if (Array.IndexOf(doorIndex, 1) == -1)
                {
                    SetValue(CanProperties.DoorBackRight, "Open");
                }
                else
                {
                    SetValue(CanProperties.DoorBackRight, "Close");
                };
                return canMessage; 
            }           
            else
            {
                return base.Handle(canMessage);
            }
        }
        public static int[] AllIndexesOf(string str, string substr, bool ignoreCase = false)
        {
            if (string.IsNullOrWhiteSpace(str) ||
                string.IsNullOrWhiteSpace(substr))
            {
                throw new ArgumentException("String or substring is not specified.");
            }

            var indexes = new List<int>();
            var index = 0;

            while ((index = str.IndexOf(substr, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) != -1)
            {
                indexes.Add(index++);
            }

            return indexes.ToArray();
        }
    }
}
