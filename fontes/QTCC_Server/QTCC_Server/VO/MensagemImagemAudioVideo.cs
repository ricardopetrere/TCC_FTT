using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    class MensagemImagemAudioVideo : Mensagem
    {
        #region Propriedades
        #region Tamanho_Arquivo
        [DataMember(Name = Campos.Tamanho_Arquivo)]
        public int Tamanho_Arquivo
        {
            get;
            set;
        }
        #endregion Tamanho_Arquivo
        #endregion

        #region Campos em JSON
        public static class Campos
        {
            public const string Tamanho_Arquivo = "Tamanho_Arquivo";
        }
        #endregion Campos em JSON
    }
}
