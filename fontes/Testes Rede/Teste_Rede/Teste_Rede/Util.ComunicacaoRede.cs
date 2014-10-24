using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Util
{
    public class ComunicacaoRede : INotifyPropertyChanged
    {
        private static int porta_tcp = 5500;
        private Thread tEscutaClientes;
        private TcpListener listener;
        private String _texto_recebido;
        public String Texto_Recebido
        {
            get 
            {
                return _texto_recebido; 
            }
            set
            {
                _texto_recebido = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Texto_Recebido"));
            }
        }
        //[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, ControlThread = true)]
        public void ParaThread()
        {
            listener.Stop();
            tEscutaClientes.Abort();
        }
        #region Envio pela Rede
        //http://tech.pro/tutorial/704/csharp-tutorial-simple-threaded-tcp-server
        #region Cliente
        public static String EnviarPacote(String dado)
        {
            TcpClient client = new TcpClient("127.0.0.1", 5500);
            NetworkStream s = client.GetStream();
            byte[] buffer_envio;
            buffer_envio = Encoding.ASCII.GetBytes(dado);
            s.Write(buffer_envio, 0, buffer_envio.Length);

            String retorno = "";
            byte[] buffer_recebido = new byte[1024];
            int index = 0;
            while((index = s.Read(buffer_recebido,0,buffer_recebido.Length))!=0)
            //while (s.DataAvailable)
            //    if((index = s.Read(buffer_recebido, 0, buffer_recebido.Length)) != 0)
                {
                    retorno += Encoding.ASCII.GetString(buffer_recebido);
                }
            s.Close();
            return retorno;
        }
        #endregion Cliente
        #region Servidor
        
        public void ReceberPacote(object objClient)
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
                        retorno += Encoding.ASCII.GetString(buffer, 0, offset);
                    }
                byte[] resposta = Encoding.ASCII.GetBytes("Recebido");
                s.Write(resposta, 0, resposta.Length);
                s.Close();
                client.Close();
                Texto_Recebido = retorno;
                //ExecutarBind(retorno);
                //Console.WriteLine(retorno);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
        //void ExecutarBind(String valor)
        //{
        //    Texto_Recebido = valor;
        //}
        public void IniciarServidor()
        {
            tEscutaClientes = new Thread(new ThreadStart(EscutaClientes));
            tEscutaClientes.Start();
            //Console.WriteLine("tEscutaClientes");
        }
        private void EscutaClientes()
        {
            listener = new TcpListener(IPAddress.Loopback, porta_tcp);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread tReceberPacote = new Thread(new ParameterizedThreadStart(ReceberPacote));
                tReceberPacote.Start(client);
                //Console.WriteLine("tReceberPacote");
            }
        }
        #endregion Servidor
        #endregion Envio pela Rede

        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}
