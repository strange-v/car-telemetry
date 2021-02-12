using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using CT.BusinessLogic.Interfaces;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Configuration;
using System.Collections.Specialized;


namespace CT.BusinessLogic.Services
{
    public class SerialService : ISerialService
    {
        public string SerialPortValue { get; set; }
        public SerialService()
        {
            string buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = buildDir + @"\SerialPortConfig.json";
            string jsonString = File.ReadAllText(filePath);
            SerialSettings _sersetting = JsonSerializer.Deserialize<SerialSettings>(jsonString);

            System.IO.Ports.SerialPort mySerialPort = new System.IO.Ports.SerialPort(_sersetting.COMPort);

            mySerialPort.BaudRate = _sersetting.BaudRate;
            mySerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), _sersetting.Parity, true);
            mySerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _sersetting.StopBits, true);
            mySerialPort.DataBits = _sersetting.DataBits;
            mySerialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), _sersetting.Handshake, true); ;

            mySerialPort.NewLine = (@"&N");

            try
            {
                if (!mySerialPort.IsOpen)
                {
                    mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
                    mySerialPort.Open();
                }
            }
            catch
            {
                
            }
        }

        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
            try
            {
                string indata = sp.ReadExisting();
                SerialPortValue = indata.ToString();
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
