using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using QTCC_Server.CS;

namespace QTCC_Server
{
    public static class ComunicacaoRede
    {
        #region Propriedades
        private static TcpListener listener = null;
        private static String ip_listener = "127.0.0.1";
        private static Int16 porta_listener = 8733;
        //private static Thread thread_listen;
        //private static Task task_listen;
        private static System.ComponentModel.BackgroundWorker b = new System.ComponentModel.BackgroundWorker();
        #endregion

        #region Métodos
        public static void AbreConexao()
        {
            InicializaConexao();
            b.WorkerReportsProgress = true;
            b.WorkerSupportsCancellation = true;
            b.DoWork += b_DoWork;
            b.RunWorkerAsync();
        }

        private static void b_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ReceberPacotes();
        }

        /// <summary>
        /// Escuta a rede em busca de conexões para envio de dados
        /// <para/>
        /// Os pacotes são enviados da seguinte maneira:
        /// <para/>
        /// Tipo de pacote (Mensagem, Contato) + Pipeline (|) + Objeto (em Json)
        /// </summary>
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
                    Byte[] retorno = System.Text.Encoding.ASCII.GetBytes(CONSTANTES.StatusEnvioEnum.EnviadoAoServidor.ToString());
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
                listener = new TcpListener(System.Net.IPAddress.Parse(ip_listener), porta_listener);
            listener.Start();
        }

        public static void FechaConexao()
        {
            b.CancelAsync();
            if (listener != null)
                listener.Stop();
        }

        public static void TrataPacote(String pacote)
        {

        }
        #endregion
    }
}
