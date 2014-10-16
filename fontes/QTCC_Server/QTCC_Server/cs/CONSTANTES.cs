using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.CS
{
    public static class CONSTANTES
    {
        public enum MensagemTipoEnum { GravacaoVoz=1,Texto=2,Imagem=3,Audio=4,Video=5};
        public enum StatusEnvioEnum { EntregaPendente=1,EnviadoAoServidor=2,DestinatarioRecebeu=3};
    }
}
