using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QTCC_Server.Controller;
using QTCC_Server.VO;

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
            CONSTANTES.TiposPacotesDadosEnum TipoPacote;
            if (Enum.TryParse(dados_pacote[0], out TipoPacote))
            {
                try
                {
                    //OPCode
                    switch (TipoPacote)
                    {
                        case CONSTANTES.TiposPacotesDadosEnum.RequisicaoLogin:
                            retorno = new RequisicaoLoginController().RequisicaoLogin(JSON_Logic.Deserializa<RequisicaoLogin>(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.ReceberNovasMensagens:
                            retorno = JSON_Logic.Serializa<List<Mensagem>>(new MensagemController().ReceberNovasMensagens(Convert.ToInt32(dados_pacote[1])));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.EnviarNovaMensagem:
                            retorno = new MensagemController().EnviarNovaMensagem(JSON_Logic.Deserializa<Mensagem>(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.StatusContato:
                            retorno = new ContatoController().StatusContato(Convert.ToInt32(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.StatusMensagem:
                            retorno = new MensagemController().StatusMensagem(Convert.ToInt32(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.NovoCadastro:
                            retorno = new UsuarioController().NovoCadastro(JSON_Logic.Deserializa<Usuario>(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.EnviarNovoUsuario:
                            retorno = new UsuarioController().EnviarNovoUsuario(JSON_Logic.Deserializa<UsuarioAdicionado>(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.EnviarNovoGrupo:
                            retorno = new UsuarioController().EnviarNovoGrupo(JSON_Logic.Deserializa<Grupo>(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.BuscaUsuarioPeloEmail:
                            retorno = JSON_Logic.Serializa<Usuario>(new UsuarioController().Busca(dados_pacote[1]));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.BuscaUsuarioPeloID:
                            retorno = JSON_Logic.Serializa<Usuario>(new UsuarioController().Busca(Convert.ToInt32(dados_pacote[1])));
                            break;
                        case CONSTANTES.TiposPacotesDadosEnum.BuscaContato:
                            retorno = JSON_Logic.Serializa<Contato>(new ContatoController().Busca(Convert.ToInt32(dados_pacote[1])));
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
