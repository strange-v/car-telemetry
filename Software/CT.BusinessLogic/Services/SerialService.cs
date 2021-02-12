using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using CT.BusinessLogic.Interfaces;
using System.IO;
using System.Reflection;
using System.Collections.Specialized;


namespace CT.BusinessLogic.Services
{
    public class SerialService : ISerialService
    {
        private readonly IConfiguration Configuration;
        public string SerialPortValue { get; set; }
        public SerialService(IConfiguration configuration)
        {
            Configuration = configuration;
            var comPort = Configuration["COMPort"];
            int baudRate = int.Parse(Configuration["BaudRate"]);
            var parity = Configuration["Parity"];
            var stopBits = Configuration["StopBits"];
            int dataBits = int.Parse(Configuration["DataBits"]);
            var handshake = Configuration["Handshake"];

            System.IO.Ports.SerialPort mySerialPort = new System.IO.Ports.SerialPort(comPort);

            mySerialPort.BaudRate = baudRate;
            mySerialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity, true);
            mySerialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
            mySerialPort.DataBits = dataBits;
            mySerialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), handshake, true); ;

            mySerialPort.NewLine = (@"&N");
            
            /* while(true)
            {
            if (!mySerialPort.IsOpen)
                {
                    mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceivedHandler);
                    mySerialPort.Open();
                    break;
                    Debug.WriteLine("Conection fail!");
                }
            }*/
             
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
                //Допрацювати exception
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
