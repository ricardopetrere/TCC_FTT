﻿using System;
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
            TcpClient client = (TcpClient)objClient;
            NetworkStream s = client.GetStream();
            try
            {
                String recebido = "";
                byte[] buffer = new byte[1024];
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
                    else
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

                Console.WriteLine(recebido);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            finally
            {
                s.Close();
                client.Close();
            }
        }
        /// <summary>
        /// Método responsável por iniciar a escuta da porta TCP
        /// </summary>
        public static void IniciarServidor()
        {
            //Inicializa a Thread que irá escutar a porta TCP, com o método responsável
            Thread tEscutaClientes = new Thread(new ThreadStart(EscutaClientes));
            //Necessário para que a Thread seja eliminada junto com a aplicação
            tEscutaClientes.IsBackground = true;
            //Inicia a execução da Thread
            tEscutaClientes.Start();
        }
        private static void EscutaClientes()
        {
            listener = new TcpListener(IPAddress.Parse("192.168.1.34"), porta_tcp);
            listener.Start();
            esta_escutando_porta = true;
            while (true && Esta_Escutando_Porta)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread tReceberPacote = new Thread(new ParameterizedThreadStart(ReceberPacote));
                    tReceberPacote.IsBackground = true;
                    tReceberPacote.Start(client);
                }
                catch
                {

                }
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
