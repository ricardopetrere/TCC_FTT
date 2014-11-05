using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace QTCC_Server.Util
{//http://stackoverflow.com/questions/5883282/binding-property-to-control-in-winforms
    public static class ComunicacaoRede
    {
        public static event EventHandler onPacoteRecebido;
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
        private static bool esta_escutando_porta = false;
        public static bool Esta_Escutando_Porta
        {
            get
            {
                return esta_escutando_porta;
            }
        }
        private static TcpListener listener;
        //http://tech.pro/tutorial/704/csharp-tutorial-simple-threaded-tcp-server
        #region Servidor
        public static void ReceberPacote(object objClient)
        {
            try
            {
                TcpClient client = (TcpClient)objClient;
                String recebido = "";
                byte[] buffer = new byte[1024];
                NetworkStream s = client.GetStream();
                int offset;
                while ((offset = s.Read(buffer, 0, buffer.Length)) != 0 )
                {
                    recebido += Encoding.Default.GetString(buffer, 0, offset);
                    if (!s.DataAvailable)
                        break;
                }
                byte[] resposta;
                try
                {
                    if (onPacoteRecebido != null)
                    {
                        onPacoteRecebido(recebido, new EventArgs());
                    }
                    else//Como poderia cair aqui??
                    {
                        Console.WriteLine("onPacoteRecebido não instanciado!");
                    }
                    resposta = Encoding.Default.GetBytes(ComunicacaoController.TrataPacote(recebido));
                }
                catch(Exception e)
                {
                    resposta = Encoding.Default.GetBytes("Falha: "+e.Message);
                }
                s.Write(resposta, 0, resposta.Length);
                s.Close();
                client.Close();

                Console.WriteLine(recebido);
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
            esta_escutando_porta = true;
            while (true && Esta_Escutando_Porta)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread tReceberPacote = new Thread(new ParameterizedThreadStart(ReceberPacote));
                tReceberPacote.IsBackground = true;
                tReceberPacote.Start(client);
            }
        }
        public static void FechaConexao()
        {
            listener.Stop();
            esta_escutando_porta = false;
        }
        #endregion Servidor
    }
}
