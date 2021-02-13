using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Diagnostics;
using System.IO.Ports;

namespace CT.Web.Pages
{
    public class IndexModel : ComponentBase
    {
        public string styleDoorDriver { get; set; } = "";
        public string styleDoorPassenger { get; set; } = "";
        public string styleDoorBackLeft { get; set; } = "";
        public string styleDoorBackRight { get; set; } = "";
        public int handbrake { get; set; } = 1;
    }
}

