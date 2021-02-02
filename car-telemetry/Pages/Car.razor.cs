using Microsoft.AspNetCore.Components;
using System;

namespace car_telemetry.Pages
{
    public class CarModel : ComponentBase
    {
        public int[] DriverOpened { get; set; } = { 0, 0, 0, 0 };
        public int[] doors { get; set; } = { 0, 0, 0, 0 };

        public void RandArr()
        {
            var random = new Random();
            var value = random.Next(2);
            doors[0] = value;
            value = random.Next(2);
            doors[1] = value;
            value = random.Next(2);
            doors[2] = value;
            value = random.Next(2);
            doors[3] = value;
        }
        public void CloseAll()
        {
            Array.Clear(doors, 0, doors.Length);
        }

    }
}
