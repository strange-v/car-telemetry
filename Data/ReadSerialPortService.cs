using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;

namespace TEST1.Data
{
    public class ReadSerialPortService
    {
        public string SerialPortValue { get; set; }

        public ReadSerialPortService()
        {
            System.IO.Ports.SerialPort mySerialPort = new System.IO.Ports.SerialPort("COM3");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = System.IO.Ports.Parity.None;
            mySerialPort.StopBits = System.IO.Ports.StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = System.IO.Ports.Handshake.None;

            mySerialPort.NewLine = (@"&N");

            if (mySerialPort.IsOpen)
            {
                return;
            }
            mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.Open();
        }

        private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
            double scaleDec = 0.00;
            try
            {
                string indata = sp.ReadLine();
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
