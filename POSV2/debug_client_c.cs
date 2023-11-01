using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace POSV2
{
    class debug_client_c
    {
        public void enviar(string msj)
        {
            // data buffer for incoming data 
            byte[] bytes = new byte[1024];
            string miip = "";
            // connect to a Remote device 
            try
            {
                // Establish the remote end point for the socket 
                IPHostEntry ipHost = Dns.GetHostEntry("127.0.0.1");
                IPAddress ipAddr = null;
                //Console.WriteLine(ipHost.AddressList[0].ToString());
                if (ipHost.AddressList[0].ToString() != "::1")
                {
                    ipAddr = ipHost.AddressList[0];
                }
                else {
                    ipAddr = ipHost.AddressList[1];
                }

                miip = ipAddr.ToString();
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 2345);

                Socket sender = new Socket(AddressFamily.InterNetwork,
                                           SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint 

                sender.Connect(ipEndPoint);

                Console.WriteLine("Socket connected to {0}",
                sender.RemoteEndPoint.ToString());

                string theMessage = msj + "\n"; //"This is a test";

                byte[] msg = Encoding.ASCII.GetBytes(theMessage + "<theend>");

                // Send the data through the socket 
                int bytesSent = sender.Send(msg);
                /*
                // Receive the response from the remote device 
                int bytesRec = sender.Receive(bytes);

                Console.WriteLine("The Server says : {0}",
                                  Encoding.ASCII.GetString(bytes, 0, bytesRec));

                // Release the socket 
                sender.Shutdown(SocketShutdown.Both);
                */
                sender.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error con Servidor Debug ip="+miip);
                Console.WriteLine("Exception: {0}", e.ToString());
                first.debugServerDown = true;
            }
        }
    }
}
