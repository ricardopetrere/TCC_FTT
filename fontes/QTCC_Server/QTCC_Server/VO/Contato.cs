using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    class Contato : EntidadeBase
    {
        #region Propriedades
        #region IDContato
        [DataMember(Name = Campos.IDContato)]
        public int IDContato
        {
            get;
            set;
        }
        #endregion IDContato

        #region Nome
        [DataMember(Name = Campos.Nome)]
        public String Nome
        {
            get;
            set;
        }
        #endregion Nome

        #region Foto
        public Image Foto
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Foto)]
        String Foto_String
        {
            get
            {//http://www.c-sharpcorner.com/Forums/Thread/240427/image-transfer-using-json.aspx
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    Foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            set
            {
                Image i;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    ms.Write(Encoding.Default.GetBytes(value), 0, value.Length);
                    i = Image.FromStream(ms);
                    this.Foto = i;
                }
            }
        }
        #endregion Foto

        #region Inativo
        [DataMember(Name = Campos.Inativo)]
        private Boolean Inativo
        {
            get;
            set;
        }
        #endregion Inativo
        #endregion

        public static class Campos
        {
            public const string IDContato = "IDContato";
            public const string Nome = "Nome";
            public const string Foto = "Foto";
            public const string Inativo = "Inativo";
        }

        #region Métodos
        public Contato()
        {
            IDContato = -1;
            Nome = "";
            Foto = null;
            Inativo = false;
        }

        public static Contato MontaVO(System.Data.DataRow registro)
        {
            throw new NotImplementedException();
        }

        public static int InsereContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public static int AlteraContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public static int ExcluiContato(int id_contato)
        {
            throw new NotImplementedException();
        }

        public static Contato BuscaContato(int id_contato)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
