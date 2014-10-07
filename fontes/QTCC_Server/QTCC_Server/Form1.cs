using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CFG_BD_XML;

namespace QTCC_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarListaContatos(listBox1.SelectedIndex >= 0);
        }

        private void MostrarListaContatos(bool mostrar)
        {
            if (mostrar)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(new frConexaoBD().ShowDialog()==DialogResult.OK)
            {
                
            }
        }
    }
}
