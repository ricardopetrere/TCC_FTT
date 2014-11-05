using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Serializar_Image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEscolherImagem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            Objeto o = new Objeto();
            o.Foto = picFoto.Image;

            String s = JSON_Logic.Serializa<Objeto>(o);

            File.WriteAllText("Imagem.json", s);

        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            String s = File.ReadAllText("Imagem.json");

            Objeto o = JSON_Logic.Deserializa<Objeto>(s);
            
            picFoto.Image = o.Foto;
        }
    }
    [DataContract]
    public class Objeto
    {
        [DataMember(Name = "Foto")]
        public String Foto_String
        {
            get
            {
                return Foto.ToString();
            }
        }
        public Image Foto 
        {
            get
            {

            }
            set
            {

            }
        }
    }
    public class JSON_Logic
    {
        public static String Serializa<T>(T item)
        {
            String retorno;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            System.IO.MemoryStream s = new System.IO.MemoryStream();
            serializer.WriteObject(s, item);
            retorno = Encoding.UTF8.GetString(s.ToArray());
            s.Close();
            return retorno;
        }
        public static T Deserializa<T>(String dados)
        {
            T retorno;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            System.IO.MemoryStream s = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dados));
            retorno = (T)serializer.ReadObject(s);
            s.Close();
            return retorno;
        }
    }
}
