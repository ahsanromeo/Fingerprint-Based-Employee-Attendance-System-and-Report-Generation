using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace FPM
{
    public class OnlineConnection
    {
        MySqlConnection conn = null;
        string connString = "";
        Ping ping = null;
        private string checkingUrl = "www.google.com.mx";
        public OnlineConnection()
        {
            connString = "SERVER= IPADDRESS;PORT=PORT_NUMBER;DATABASE=DATABASE_NAME;UID=USER_ID;PASSWORD=PASSWORD";
            ping = new Ping();
        }
        public bool insert(string q)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                conn.Close();
                conn = null;
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn = null;
                return false;
            }
        }
        public DataTable query(string q)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                conn = null;
                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn = null;
                return null;
            }
        }

        public string sendAndReceiveResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        bool hc;

        public bool hasConnection()
        {
            hc = false;
            using (WaitForm wf = new WaitForm(check, "Connecting..."))
            {
                wf.ShowDialog();
            }
            return hc;
        }

        private void check()
        {
            try
            {
                hc = ping.Send(checkingUrl).Status == IPStatus.Success;
            }
            catch (Exception)
            {
                hc = false;
            }
        }
    }
}
