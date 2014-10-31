using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Util
{
    public class ComunicacaoController
    {
        //internal static void ComunicacaoRede_onPacoteRecebido(object sender, EventArgs e)
        //{
        //    //Arrumar para usar pipeline mesmo. Está estranho e aparentemente errado desse jeito
        //    PacoteBaseJSON p = JSON_Logic.Deserializa<PacoteBaseJSON>(sender.ToString());
        //    switch (p.TipoPacote)
        //    {
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.RequisicaoLogin:
        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.ReceberNovasMensagens:
        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovaMensagem:

        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.StatusContato:
        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.StatusMensagem:
        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.NovoCadastro:
        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovoUsuario:
        //            break;
        //        case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovoGrupo:
        //            break;
        //        default:
        //            break;
        //    }
        //}

        internal static void ComunicacaoRede_onPacoteRecebido(object sender, EventArgs e)
        {
            string[] dados_pacote = sender.ToString().Split('|');
            VO.CONSTANTES.TiposPacotesDados TipoPacote;
            if (Enum.TryParse(dados_pacote[0], out TipoPacote))
                switch (TipoPacote)
                {
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.RequisicaoLogin:
                        VO.RequisicaoLogin login = JSON_Logic.Deserializa<VO.RequisicaoLogin>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.ReceberNovasMensagens:
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovaMensagem:
                        VO.Mensagem m = JSON_Logic.Deserializa<VO.Mensagem>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.StatusContato:
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.StatusMensagem:
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.NovoCadastro:
                        VO.Usuario u = JSON_Logic.Deserializa<VO.Usuario>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovoUsuario:
                        VO.Usuario novo_u = JSON_Logic.Deserializa<VO.Usuario>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDados.EnviarNovoGrupo:
                        VO.Grupo g = JSON_Logic.Deserializa<VO.Grupo>(dados_pacote[1]);
                        break;
                    default:
                        break;
                }
        }
    }
}
