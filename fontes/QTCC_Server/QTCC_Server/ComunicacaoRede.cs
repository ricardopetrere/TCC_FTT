using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace QTCC_Server
{
    public static class ComunicacaoRede
    {
        #region Propriedades
        private static TcpListener listener = null;
        private static Int16 porta_listener = 8733;
        private static Thread thread_listen;
        private static Task task_listen;
        #endregion

        #region Métodos
        public static void AbreConexao()
        {
            InicializaConexao();
            System.ComponentModel.BackgroundWorker b = new System.ComponentModel.BackgroundWorker();
            b.DoWork += b_DoWork;
            b.RunWorkerAsync();
        }

        private static void b_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ReceberPacotes();
        }

        private static void ReceberPacotes()
        {
            try
            {

                //http://msdn.microsoft.com/pt-br/library/system.net.sockets.tcplistener(v=vs.110).aspx
                Byte[] bytes = new Byte[256];
                String data = null;
                while (true)
                {
                    String recebido = "";

                    TcpClient client = listener.AcceptTcpClient();
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        recebido += data;
                    }
                    Byte[] retorno = System.Text.Encoding.ASCII.GetBytes("Recebido pelo Servidor.");
                    stream.Write(retorno, 0, retorno.Length);
                    client.Close();
                }
            }
            catch
            {

            }
        }

        private static void InicializaConexao()
        {
            if (listener == null)
                listener = new TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), porta_listener);
            listener.Start();
        }

        public static void FechaConexao()
        {
            if (listener != null)
                listener.Stop();
        }
        #endregion
    }
}
