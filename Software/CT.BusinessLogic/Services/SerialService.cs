using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO.Ports;
using CT.BusinessLogic.Interfaces;

namespace CT.BusinessLogic.Services
{
    public class SerialService : ISerialService
    {
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

            _mySerialPort.NewLine = (@"&N");

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

        public event Func<Task> Notify;

        private readonly IConfiguration Configuration;
        public string SerialPortValue { get; set; }
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            GC.KeepAlive(sender);
            SerialPort myserialPort = (SerialPort)sender;
            try
            {
                string indata = myserialPort.ReadExisting();
                SerialPortValue = indata.ToString();
                if (Notify != null)
                {
                    Notify.Invoke();
                }
            }
            catch
            {
                
            }

        }
        public Task<string> GetSerialValue()
        {
            return Task.FromResult(SerialPortValue);
        }
    }
}
