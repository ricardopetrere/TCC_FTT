using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.CS
{
    class Mensagem : EntidadeBase
    {
        #region Propriedades
        private int Id
        {
            get;
            set;
        }

        public Contato Contato_De
        {
            get;
            set;
        }

        public Contato Contato_Para
        {
            get;
            set;
        }

        public DateTime Data_Envio
        {
            get;
            set;
        }

        public CONSTANTES.StatusEnvioEnum Status_Envio
        {
            get;
            set;
        }

        public CONSTANTES.MensagemTipoEnum Tipo_Mensagem
        {
            get;
            set;
        }

        public Byte[] Dados
        {
            get;
            set;
        }

        private Boolean Contato_De_Deletou
        {
            get;
            set;
        }

        private Boolean Contato_Para_Deletou
        {
            get;
            set;
        }
        #endregion
        #region Métodos
        public Mensagem()
        {
            Id = -1;
            Contato_De = null;
            Contato_Para = null;
            Data_Envio = new DateTime();
            Status_Envio = CONSTANTES.StatusEnvioEnum.EntregaPendente;
            Tipo_Mensagem = CONSTANTES.MensagemTipoEnum.Texto;
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
