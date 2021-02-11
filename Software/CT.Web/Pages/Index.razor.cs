using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Diagnostics;
using System.IO.Ports;

namespace CT.Web.Pages
{
    public class IndexModel : ComponentBase
    {
        public int[] DriverOpened { get; set; } = { 0, 0, 0, 0 };
        public int[] doors { get; set; } = { 0, 0, 0, 0 };
        public int handbrake { get; set; } = 1;

    }
}

