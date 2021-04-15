using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A24_Sport_Title_Controller.Core.Operations
{
    public class TCPOperations
    {
        System.Net.Sockets.TcpClient casparClient = new System.Net.Sockets.TcpClient();

        private List<string> tlsList = new List<string>();

        public List<string> GetList()
        {
            return tlsList;
        }

        public bool Connect(string IP, string Port)
        {
            try
            {
                //casparClient.Connect(IP, int.Parse(Port));
                GetTLS("TLS");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            casparClient.Close();
            casparClient = new System.Net.Sockets.TcpClient();
        }

        public bool GetTLS(string message)
        {
            try
            {
                //var reader = new StreamReader(casparClient.GetStream());
                //var writer = new StreamWriter(casparClient.GetStream());
                //writer.WriteLine(message);
                //writer.Flush();
                //var reply = reader.ReadLine();

                //if (reply.Contains("200"))
                //{
                //    tlsList.Clear();
                //    while (reply.Length > 0)
                //    {
                //        reply = reader.ReadLine();
                //        tlsList.Add(reply);
                //    }
                //}
                //return true;
                tlsList.Add("1");
                tlsList.Add("2");
                tlsList.Add("3");
                tlsList.Add("4");
                tlsList.Add("5");
                tlsList.Add("6");
                tlsList.Add("7");
                tlsList.Add("8");
                tlsList.Add("9");
                tlsList.Add("10");
                return true;

            }
            catch
            {
                System.Windows.MessageBox.Show("Связь с сервером не установлена!", "Ошибка!");
                return false;
            }
        }

        public bool SendMessage(string message)
        {
            try
            {
                var reader = new StreamReader(casparClient.GetStream());
                var writer = new StreamWriter(casparClient.GetStream());
                writer.WriteLine(message);
                writer.Flush();
                var reply = reader.ReadLine();
                return true;
            }
            catch
            {
                System.Windows.MessageBox.Show("Связь с сервером не установлена!", "Ошибка!");
                return false;
            }           
        }
    }
}
