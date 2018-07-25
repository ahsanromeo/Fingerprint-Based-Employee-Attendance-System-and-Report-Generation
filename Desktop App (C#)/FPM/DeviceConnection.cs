using System;
using System.IO.Ports;

namespace FPM
{
    public class DeviceConnection
    {
        private string[] ports;
        SerialPort port;
        public DeviceConnection()
        {
            ports = SerialPort.GetPortNames();
            port = null;
        }
        public string[] getAvailablePorts()
        {
            return ports;
        }
        public bool connect(string p)
        {
            try
            {
                port = new SerialPort(p, 9600);
                port.Open();
                port.Write("START\n");
                return port.IsOpen;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public void disconnect()
        {
            if (port == null)
                return;
            if (port.IsOpen)
            {
                port.Write("STOP\n");
                port.Close();
            }
        }
        public bool send(string s)
        {
            try
            {
                port.Write(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string get()
        {
            return port.ReadLine();
        }
        public int dataCount()
        {
            return port.BytesToRead;
        }

        public bool deleteRequest(int id)
        {
            try
            {
                return send("DELETE " + id.ToString() + "\n");
            }
            catch(Exception)
            {
                return false;
            }
        }
        public string wait()
        {
            try
            {
                DateTime sTime = DateTime.Now;
                while(dataCount() == 0)
                {
                    DateTime curr = DateTime.Now;
                    int ep = Convert.ToInt32(Math.Floor(curr.Subtract(sTime).TotalSeconds));
                    if(ep > 2)
                    {
                        return "OPERATION TIME OUT";
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
