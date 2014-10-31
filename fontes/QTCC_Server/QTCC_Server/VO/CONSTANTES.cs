using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.VO
{
    public static class CONSTANTES
    {
        #region Enumeradores
        public enum TipoMensagemEnum 
        { 
            GravacaoVoz=1,
            Texto=2,
            Imagem=3,
            Audio=4,
            Video=5
        };
        public enum StatusEnvioEnum 
        { 
            EntregaPendente=1,
            EnviadoAoServidor=2,
            DestinatarioRecebeu=3
        };
        public enum TiposPacotesDados 
        { 
            RequisicaoLogin = 1,
            ReceberNovasMensagens=2,
            EnviarNovaMensagem=3,
            StatusContato=4,
            StatusMensagem=5,
            NovoCadastro=6,
            EnviarNovoUsuario=7,
            EnviarNovoGrupo=8
        };
        #endregion Enumeradores
    }
}
