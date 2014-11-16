using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QTCC_Server.DAO;
using QTCC_Server.VO;

namespace QTCC_Server.Controller
{
    class UsuarioController : EntidadeBaseController<Usuario>
    {
        public override int Insere(Usuario entidade)
        {
            return UsuarioDAO.Insere(entidade);
        }

        public override int Altera(Usuario entidade)
        {
            throw new NotImplementedException();
        }

        public override int Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public override Usuario Busca(int cont_id)
        {
            return UsuarioDAO.BuscaPeloId(cont_id);
        }
        public Usuario Busca(string usu_email)
        {
            return UsuarioDAO.BuscaPeloEmail(usu_email);
        }

        public override List<Usuario> Lista()
        {
            throw new NotImplementedException();
        }

        #region Métodos de ComunicacaoController
        public String NovoCadastro(Usuario usuario)
        {
            int ID_Inserido = Insere(usuario);
            if ( ID_Inserido > 0)
                return "Cadastro efetuado com sucesso";
            else
                return "Falha no cadastro";
        }

        public string EnviarNovoUsuario(UsuarioAdicionado usuarioAdicionado)
        {
            if(usuarioAdicionado.NovoUsuario==null)
            {
                return "Não existe nenhum usuário com esse e-mail.";
            }
            else
            {
                if(ContatoDAO.AdicionaContatoListaContatos(usuarioAdicionado.IDContato,usuarioAdicionado.NovoUsuario.IDContato))
                {
                    return "Usuário adicionado à lista de contatos como sucesso!";
                }
                else
                {
                    return "Falha ao adicionar o usuário à lista de contatos.";
                }
            }
        }

        public string EnviarNovoGrupo(Grupo grupo)
        {
            throw new NotImplementedException();
        }
        #endregion Métodos de ComunicacaoController
    }
}
