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
                try
                {

                    switch (TipoPacote)
                    {
                        case VO.CONSTANTES.TiposPacotesDadosEnum.RequisicaoLogin:
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.ReceberNovasMensagens:
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.EnviarNovaMensagem:
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.StatusContato:
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.StatusMensagem:
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.NovoCadastro:
                            retorno = new Controller.UsuarioController().NovoCadastro(JSON_Logic.Deserializa<VO.Usuario>(dados_pacote[1]));
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.EnviarNovoUsuario:
                            break;
                        case VO.CONSTANTES.TiposPacotesDadosEnum.EnviarNovoGrupo:
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    return retorno;
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
