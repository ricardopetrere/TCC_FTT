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
        /// <summary>
        /// Trata o pacote recebido via rede, redirecionando-o para o método correspondente
        /// </summary>
        /// <param name="pacote_recebido">O pacote recebido, no esquema (Identificador|dados)</param>
        /// <returns>A resposta do servidor</returns>
        public static String TrataPacote(string pacote_recebido)
        {
            String retorno = "";
            //Separa o pacote, entre identificador (OP Code) e dados
            string[] dados_pacote = pacote_recebido.ToString().Split('|');
            //Tenta converter a primeira parte do pacote para o enumerador de identificadores
            CONSTANTES.TiposPacotesDadosEnum TipoPacote;
            if (Enum.TryParse(dados_pacote[0], out TipoPacote))
            {
                try
                {
                    //Verifica o OP Code passado no pacote
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
                            retorno = new MensagemController().StatusMensagem(JSON_Logic.Deserializa<Mensagem>(dados_pacote[1])).ToString();
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
                        default://Se o OP Code não estiver listado acima, está errado
                            throw new NotImplementedException();
                    }
                    return retorno;
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
            else//Se não conseguiu encontrar um OP Code da primeira parte do pacote, lança exceção
            {
                throw new InvalidCastException();
            }
        }
    }
}
