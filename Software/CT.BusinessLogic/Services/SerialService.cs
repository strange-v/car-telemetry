using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO.Ports;
using CT.BusinessLogic.Interfaces;

namespace CT.BusinessLogic.Services
{
    public class SerialService : ISerialService
    {
        public SerialService(IConfiguration configuration)
        {
            Configuration = configuration;
            var comPort = Configuration["COMPort"];
            int baudRate = int.Parse(Configuration["BaudRate"]);
            var parity = Configuration["Parity"];
            var stopBits = Configuration["StopBits"];
            int dataBits = int.Parse(Configuration["DataBits"]);
            var handshake = Configuration["Handshake"];

            SerialPort mySerialPort = new SerialPort(comPort)
            {
                BaudRate = baudRate,
                Parity = (Parity)Enum.Parse(typeof(Parity), parity, true),
                StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true),
                DataBits = dataBits,
                Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true)
            };
            ;

            mySerialPort.NewLine = (@"&N");

            try
            {
                if (!mySerialPort.IsOpen)
                {
                    mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    mySerialPort.Open();
                }
            }
            catch
            {

            }
        }

        public event Func<Task> Notify;

        private readonly IConfiguration Configuration;
        public string SerialPortValue { get; set; }
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            try
            {
                string indata = serialPort.ReadExisting();
                SerialPortValue = indata.ToString();
                Update();
            }
            catch
            {
                
            }

        }
        public Task<string> GetSerialValue()
        {
            return Task.FromResult(SerialPortValue);
        }
        public async Task Update()
        {
            if (Notify != null)
            {
                await Notify.Invoke();
            }
        }
    }
}
