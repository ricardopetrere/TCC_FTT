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
                    byte[] a = Convert.FromBase64String(value);
                    ms.Write(a,0,a.Length);
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

        #region Campos em JSON
        public static class Campos
        {
            public const string IDContato = EntidadeBase.Campos.ID;
            //public const string IDContato = "IDContato";
            public const string Nome = "Nome";
            public const string Foto = "Foto";
            public const string Inativo = "Inativo";
        }
        #endregion Campos em JSON

        #region Métodos
        public Contato()
        {
            IDContato = -1;
            Nome = "";
            Foto = null;
            Inativo = false;
        }
        #endregion
    }
}
