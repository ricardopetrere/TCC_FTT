using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Util
{//http://stackoverflow.com/questions/5883282/binding-property-to-control-in-winforms
    public class ComunicacaoRede
    {
        public static event EventHandler onAtualizaTela;
        private static int porta_tcp = 5500;
        public static int Porta_TCP
        {
            get
            {
                return porta_tcp;
            }
            set
            {
                porta_tcp = value;
            }
        }
        private static TcpListener listener;
        #region Envio pela Rede
        //http://tech.pro/tutorial/704/csharp-tutorial-simple-threaded-tcp-server
        #region Cliente
        public static String EnviarPacote(String dado)
        {
            TcpClient client = new TcpClient("127.0.0.1", 5500);
            NetworkStream s = client.GetStream();
            byte[] buffer_envio;
            buffer_envio = Encoding.Default.GetBytes(dado);
            s.Write(buffer_envio, 0, buffer_envio.Length);

            String retorno = "";
            byte[] buffer_recebido = new byte[1024];
            int index = 0;
            while ((index = s.Read(buffer_recebido, 0, buffer_recebido.Length)) != 0)
            //while (s.DataAvailable)
            //    if((index = s.Read(buffer_recebido, 0, buffer_recebido.Length)) != 0)
            {
                retorno += Encoding.Default.GetString(buffer_recebido);
            }
            s.Close();
            return retorno;
        }
        #endregion Cliente
        #region Servidor

        public static void ReceberPacote(object objClient)
        {
            try
            {
                TcpClient client = (TcpClient)objClient;
                String retorno = "";
                byte[] buffer = new byte[1024];
                NetworkStream s = client.GetStream();
                int offset;
                while (s.DataAvailable && (offset = s.Read(buffer, 0, buffer.Length)) != 0)
                //while (s.DataAvailable)
                //    if((offset = s.Read(buffer, 0, buffer.Length)) != 0)
                {
                    retorno += Encoding.Default.GetString(buffer, 0, offset);
                }
                byte[] resposta = Encoding.Default.GetBytes("Recebido");
                s.Write(resposta, 0, resposta.Length);
                s.Close();
                client.Close();

                if (onAtualizaTela != null)
                    onAtualizaTela(retorno, new EventArgs());

                Console.WriteLine(retorno);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        public static void IniciarServidor()
        {
            Thread tEscutaClientes = new Thread(new ThreadStart(EscutaClientes));
            tEscutaClientes.IsBackground = true;
            tEscutaClientes.Start();
        }
        private static void EscutaClientes()
        {
            listener = new TcpListener(IPAddress.Loopback, porta_tcp);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread tReceberPacote = new Thread(new ParameterizedThreadStart(ReceberPacote));
                tReceberPacote.IsBackground = true;
                tReceberPacote.Start(client);
            }
        }
        #endregion Servidor
        #endregion Envio pela Rede
    }
}
