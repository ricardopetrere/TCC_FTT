using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Util
{
    public class ComunicacaoController
    {
        //public static String TrataPacote(string pacote_recebido)
        //{
        //    //Arrumar para usar pipeline mesmo. Está estranho e aparentemente errado desse jeito
        //    PacoteBaseJSON p = JSON_Logic.Deserializa<PacoteBaseJSON>(pacote_recebido.ToString());
        //    switch (p.TipoPacote)
        //    {
        //    }
        //}

        public static String TrataPacote(string pacote_recebido)
        {
            String retorno = "";
            string[] dados_pacote = pacote_recebido.ToString().Split('|');
            VO.CONSTANTES.TiposPacotesDadosEnum TipoPacote;
            if (Enum.TryParse(dados_pacote[0], out TipoPacote))
            {
                switch (TipoPacote)
                {
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.RequisicaoLogin:
                        VO.RequisicaoLogin login = JSON_Logic.Deserializa<VO.RequisicaoLogin>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.ReceberNovasMensagens:
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.EnviarNovaMensagem:
                        VO.Mensagem m = JSON_Logic.Deserializa<VO.Mensagem>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.StatusContato:
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.StatusMensagem:
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.NovoCadastro:
                        VO.Usuario u = JSON_Logic.Deserializa<VO.Usuario>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.EnviarNovoUsuario:
                        VO.Usuario novo_u = JSON_Logic.Deserializa<VO.Usuario>(dados_pacote[1]);
                        break;
                    case QTCC_Server.VO.CONSTANTES.TiposPacotesDadosEnum.EnviarNovoGrupo:
                        VO.Grupo g = JSON_Logic.Deserializa<VO.Grupo>(dados_pacote[1]);
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
                return retorno;
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
