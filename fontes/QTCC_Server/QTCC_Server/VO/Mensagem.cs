using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    class Mensagem : EntidadeBase
    {
        #region Propriedades
        #region IDMensagem
        [DataMember(Name = Campos.IDMensagem)]
        public int IDMensagem
        {
            get;
            set;
        }
        #endregion IDMensagem

        #region Contato_De
        public Contato Contato_De
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Contato_De)]
        int Contato_De_Int
        {
            get
            {
                return Contato_De.IDContato;
            }
            set
            {
                Contato de;
                if ((de = Contato.BuscaContato(value)) != null)
                {
                    this.Contato_De = de;
                }
                else
                {
                    throw new Util.ConversaoJSONException(Contato_De);
                }
            }
        }
        #endregion Contato_De

        #region Contato_Para
        public Contato Contato_Para
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Contato_Para)]
        int Contato_Para_Int
        {
            get
            {
                return Contato_Para.IDContato;
            }
            set
            {
                Contato para;
                if ((para = Contato.BuscaContato(value)) != null)
                {
                    this.Contato_Para = para;
                }
                else
                {
                    throw new Util.ConversaoJSONException(Contato_Para);
                }
            }
        }
        #endregion Contato_Para

        #region Data_Envio
        [DataMember(Name = Campos.Data_Envio)]
        public DateTime Data_Envio
        {
            get;
            set;
        }
        #endregion Data_Envio

        #region Status_Envio
        public CONSTANTES.StatusEnvioEnum Status_Envio
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Status_Mensagem)]
        String Status_Envio_String
        {
            get
            {
                return Status_Envio.ToString();
            }
            set
            {
                CONSTANTES.StatusEnvioEnum s;
                if (Enum.TryParse<CONSTANTES.StatusEnvioEnum>(value, true, out s))
                    this.Status_Envio = s;
                else
                    throw new Util.ConversaoJSONException(Status_Envio);
            }
        }
        #endregion Status_Envio

        #region Tipo_Mensagem
        public CONSTANTES.TipoMensagemEnum Tipo_Mensagem
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Tipo_Mensagem)]
        String Tipo_Mensagem_String
        {
            get
            {
                return Tipo_Mensagem.ToString();
            }
            set
            {
                CONSTANTES.TipoMensagemEnum t;
                if (Enum.TryParse<CONSTANTES.TipoMensagemEnum>(value, true, out t))
                    this.Tipo_Mensagem = t;
                else
                    throw new Util.ConversaoJSONException(Tipo_Mensagem);
            }
        }
        #endregion Tipo_Mensagem

        #region Dados
        public Byte[] Dados
        {
            get;
            set;
        }
        [DataMember(Name = Campos.Dados)]
        String Dados_String
        {
            get { return Encoding.Default.GetString(Dados); }
            set
            {
                this.Dados = Encoding.Default.GetBytes(value);
            }
        }
        #endregion Dados

        #region Contato_De_Deletou
        [DataMember(Name = Campos.Contato_De_Deletou)]
        private Boolean Contato_De_Deletou
        {
            get;
            set;
        }
        #endregion Contato_De_Deletou

        #region Contato_Para_Deletou
        [DataMember(Name = Campos.Contato_Para_Deletou)]
        private Boolean Contato_Para_Deletou
        {
            get;
            set;
        }
        #endregion Contato_Para_Deletou
        #endregion Propriedades

        public static class Campos
        {
            public const string IDMensagem = "IDMensagem";
            public const string Contato_De = "Contato_De";
            public const string Contato_Para = "Contato_Para";
            public const string Data_Envio = "Data_Envio";
            public const string Dados = "Dados";
            public const string Contato_De_Deletou = "Contato_De_Deletou";
            public const string Contato_Para_Deletou = "Contato_Para_Deletou";
            public const string Tipo_Mensagem = "Tipo_Mensagem";
            public const string Status_Mensagem = "Status_Mensagem";
        }

        #region Métodos
        public Mensagem()
        {
            IDMensagem = -1;
            Contato_De = null;
            Contato_Para = null;
            Data_Envio = new DateTime();
            Status_Envio = CONSTANTES.StatusEnvioEnum.EntregaPendente;
            Tipo_Mensagem = CONSTANTES.TipoMensagemEnum.Texto;
            Dados = null;
            Contato_De_Deletou = false;
            Contato_Para_Deletou = false;
        }

        public static Mensagem MontaVO(System.Data.DataRow registro)
        {
            throw new NotImplementedException();
        }

        public static int InsereMensagem(Mensagem mensagem)
        {
            throw new NotImplementedException();
        }

        public static Mensagem BuscaMensagem(int id_mensagem)
        {
            throw new NotImplementedException();
        }

        public List<Mensagem> ListaMensagensPorStatus(CONSTANTES.StatusEnvioEnum status_envio)
        {
            throw new NotImplementedException();
        }

        public int DeletaMensagemParaContato(Contato contato)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
