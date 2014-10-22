using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Util
{
    public static class ComunicacaoRede
    {
        public static void Inicializa()
        {
            InicializaWorker();
            InicializaListener();
        }
        private static int porta_tcp = 5500;
        private static BackgroundWorker worker;
        private static TcpListener listener;
        public static delegate String ParaOndeLevarPacote(String pacote);
        #region worker
        private static void InicializaWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        public static bool IniciaWorker()
        {
            if(!worker.IsBusy)
            {
                worker.RunWorkerAsync();
                return true;
            }
            return false;
        }
        public static bool IniciaWorker(object argument)
        {
            if(!worker.IsBusy)
            {
                worker.RunWorkerAsync(argument);
                return true;
            }
            return false;
        }
        public static bool InterrompeWorker()
        {
            try
            {
                worker.CancelAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region listener
        private static void InicializaListener()
        {
            listener = new TcpListener(IPAddress.Loopback, porta_tcp);
        }
        private static void IniciaListener()
        {

        }
        private static void InterrompeListener()
        {

        }
        private static void ReceberPacotes()
        {
            while(true)
            {
                try
                {
                    //String dados = null;
                    String retorno = "";
                    byte[] buffer = new byte[256];
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream s = client.GetStream();
                    int offset;
                    while ((offset = s.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        //dados = Encoding.ASCII.GetString(buffer, 0, offset);
                        retorno += Encoding.ASCII.GetString(buffer, 0, offset); //dados;
                    }
                    byte[] resposta = Encoding.ASCII.GetBytes("Recebido");
                    s.Write(resposta, 0, resposta.Length);
                    s.Close();
                    client.Close();
                }
                catch
                {

                }
            }
        }
        #endregion
    }
}
