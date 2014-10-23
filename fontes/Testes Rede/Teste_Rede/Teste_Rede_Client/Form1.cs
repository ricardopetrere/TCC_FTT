using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Teste_Rede_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("127.0.0.1", 5500);
            NetworkStream s = client.GetStream();
            byte[] buffer_envio;
            buffer_envio = Encoding.ASCII.GetBytes(textBox1.Text);
            s.Write(buffer_envio, 0, buffer_envio.Length);
            while (!s.DataAvailable) { }

            String retorno = "";
            byte[] buffer_recebido = new byte[1024];
            int index = 0;
            while((index = s.Read(buffer_recebido,0,buffer_recebido.Length))!=0)
            {
                retorno += Encoding.ASCII.GetString(buffer_recebido);
            }
            s.Close();
            textBox2.Text = retorno;
        }
    }
}
