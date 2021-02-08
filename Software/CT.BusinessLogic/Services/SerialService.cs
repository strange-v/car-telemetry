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


namespace CT.BusinessLogic.Services
{
    class SerialSeting
    {
        public string COMPort { get; set; }
        public int BaudRate { get; set; }
        public string StopBits { get; set; }
        public int DataBits { get; set; }
        public string Parity { get; set; }
        public string Handshake { get; set; }
    }
    public class SerialService : ISerialService
    {
        public string SerialPortValue { get; set; }
        public SerialService()
        {
            string buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = buildDir + @"\SerialPortConfig.json";
            string jsonString = File.ReadAllText(filePath);
            SerialSeting _sersetting = JsonSerializer.Deserialize<SerialSeting>(jsonString);

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
            catch (Exception)
            {
                SerialPortValue = "Something wrong with selected COM port!";
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
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }

        public Task<string> GetSerialValue()
        {
            return Task.FromResult(SerialPortValue);
        }
    }
}
