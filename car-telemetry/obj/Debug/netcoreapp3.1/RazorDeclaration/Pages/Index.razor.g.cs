// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace car_telemetry.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using car_telemetry;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\_Imports.razor"
using car_telemetry.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\Pages\Index.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\Pages\Index.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\Pages\Index.razor"
using System.IO.Ports;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : IndexModel
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 16 "C:\Users\dzink\source\repos\car-telemetry\car-telemetry\Pages\Index.razor"
 
    
    //protected override void OnAfterRender(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //    }
    //}

    //protected override void OnInitialized()
    //{

    //    System.IO.Ports.SerialPort mySerialPort = new System.IO.Ports.SerialPort("COM4");

    //    mySerialPort.BaudRate = 9600;
    //    mySerialPort.Parity = System.IO.Ports.Parity.None;
    //    mySerialPort.StopBits = System.IO.Ports.StopBits.One;
    //    mySerialPort.DataBits = 8;
    //    mySerialPort.Handshake = System.IO.Ports.Handshake.None;

    //    mySerialPort.NewLine = (@"&N");

    //    mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);

    //    ScaleValue = "test";

    //    //I skipped this part with a return, since I don't have COM3 locally

    //    if (!mySerialPort.IsOpen)
    //    {
    //        mySerialPort.Open();
    //    }
    //}

    //public void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    //{
    //    //System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;

    //    try
    //    {
    //        SerialPort sp = (SerialPort)sender;
    //        string indata = sp.ReadExisting();
    //        ScaleValue = indata.ToString(); //WHEN I PUT DEBUG HERE I CAN SEE THE CORRECT VALUE
    //        Debug.WriteLine("\n" + ScaleValue + "\n");
    //        Temporary = ScaleValue;
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }

    //}


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
