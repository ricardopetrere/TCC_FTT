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
        /// <summary>
        /// Representa a imagem de um contato
        /// </summary>
        public Image Foto
        {
            get;
            set;
        }
        /// <summary>
        /// Propriedade que serve para converter os bytes de "Foto" para texto e vice-versa
        /// </summary>
        // O atributo DataMember Indica que a propriedade abaixo é que será utilizada na serialização/deserialização
        [DataMember(Name = Campos.Foto)]
        String Foto_String
        {
            get
            {//http://www.c-sharpcorner.com/Forums/Thread/240427/image-transfer-using-json.aspx
                //Com "using", é garantido que, no final do bloco de código, o objeto "ms" será disposto, mesmo ocorrendo exceção
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    //Armazena em "ms" os bytes de "Foto" com o formato de imagem "PNG"
                    Foto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    //Retorna os bytes de ms em texto com codificação Base64
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            set
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    //Extrai os bytes a partir do texto com codificação Base64
                    byte[] a = Convert.FromBase64String(value);
                    //Armazena os bytes de "a" em "ms"
                    ms.Write(a,0,a.Length);
                    //Gera a imagem a partir dos bytes de "ms", e atribui à "Foto"
                    this.Foto = Image.FromStream(ms);
                }
            }
        }
        #endregion Foto

        #region Inativo
        [DataMember(Name = Campos.Inativo)]
        public Boolean Inativo
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
