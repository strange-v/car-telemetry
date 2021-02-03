using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace car_telemetry.Data
{
    public class SerialService
    {
        public string SerialPortValue { get; set; }

        public SerialService()
        {
            System.IO.Ports.SerialPort mySerialPort = new System.IO.Ports.SerialPort("COM4");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = System.IO.Ports.Parity.None;
            mySerialPort.StopBits = System.IO.Ports.StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = System.IO.Ports.Handshake.None;

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
            double scaleDec = 0.00;
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
