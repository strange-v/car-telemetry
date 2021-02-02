using System;
using System.IO.Ports;
using System.Diagnostics;
using Microsoft.AspNetCore.Components;

namespace TEST1.Data
{
    public class SerialInformation : ComponentBase
    {
        
        public System.IO.Ports.SerialPort SerialPort { get; set; }

        
        public static void GetPorts()
        {
            Console.WriteLine("Serial ports available:");
            Console.WriteLine("-----------------------");
            
            foreach (var portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                Console.WriteLine(portName);
            }
        }
        public void ReadFromPort()
        {
            // Initialise the serial port on COM4.
            // obviously we would normally parameterise this, but
            // this is for demonstration purposes only.
            this.SerialPort = new System.IO.Ports.SerialPort("COM3")
            {
                BaudRate = 9600,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };

            // Subscribe to the DataReceived event.
            this.SerialPort.DataReceived += SerialPortDataReceived;

            // Now open the port.
            this.SerialPort.Open();
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (System.IO.Ports.SerialPort)sender;

            // Read the data that's in the serial buffer.
            var serialdata = serialPort.ReadExisting();

            // Write to debug output.
            Debug.Write(serialdata);
        }

        public void All()
        {
            SerialInformation.GetPorts();

            var serialInformation = new SerialInformation();

            serialInformation.ReadFromPort();

            Console.ReadKey();

            serialInformation.SerialPort.Close();
        }
    }
}
