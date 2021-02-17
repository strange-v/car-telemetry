namespace CT.BusinessLogic.Services
{
    class SerialSettings
    {
        public string COMPort { get; set; }
        public int BaudRate { get; set; }
        public string StopBits { get; set; }
        public int DataBits { get; set; }
        public string Parity { get; set; }
        public string Handshake { get; set; }
    }
}
