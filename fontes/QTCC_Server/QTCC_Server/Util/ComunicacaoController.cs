using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Util
{
    public class ComunicacaoController
    {
        internal static void ComunicacaoRede_onPacoteRecebido(object sender, EventArgs e)
        {
            //Arrumar para usar pipeline mesmo. Está estranho e aparentemente errado desse jeito
            PacoteBaseJSON p = JSON_Logic.Deserializa<PacoteBaseJSON>(sender.ToString());
            switch (p.TipoPacote)
            {
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.RequisicaoLogin:
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.ReceberNovasMensagens:
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovaMensagem:
                    
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.StatusContato:
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.StatusMensagem:
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.NovoCadastro:
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovoUsuario:
                    break;
                case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovoGrupo:
                    break;
                default:
                    break;
            }
        }
    }
}
