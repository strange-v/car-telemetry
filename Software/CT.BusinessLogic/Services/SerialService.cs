using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO.Ports;
using CT.BusinessLogic.Interfaces;

namespace CT.BusinessLogic.Services
{
    public class SerialService : ISerialService
    {
        public event Func<string, Task> Notify;
        private readonly IConfiguration Configuration;
        private readonly SerialPort _mySerialPort;
        public SerialService(IConfiguration configuration)
        {
            Configuration = configuration;
            var comPort = Configuration["COMPort"];
            int baudRate = int.Parse(Configuration["BaudRate"]);
            var parity = Configuration["Parity"];
            var stopBits = Configuration["StopBits"];
            int dataBits = int.Parse(Configuration["DataBits"]);
            var handshake = Configuration["Handshake"];

            _mySerialPort = new SerialPort(comPort)
            {
                BaudRate = baudRate,
                Parity = (Parity)Enum.Parse(typeof(Parity), parity, true),
                StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true),
                DataBits = dataBits,
                Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true)
            };
            ;

            _mySerialPort.ReadTimeout = 500;
            _mySerialPort.WriteTimeout = 500;

            try
            {
                if (!_mySerialPort.IsOpen)
                {
                    _mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    _mySerialPort.Open();
                }
            }
            catch
            {

            }
        }
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            var myserialPort = (SerialPort)sender;
            var separator = new string[] { "\r\n" };
            try
            {
                var indata = myserialPort.ReadLine();
                var splittedIndata = indata.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (var value in splittedIndata)
                {
                    if (Notify != null)
                    {
                        Notify.Invoke(value.ToString());         
                    }
                }
            }
            catch
            {
                //ToDo: Handle Exception VF
            }
        }
    }
}
