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

        public override Usuario Busca(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Usuario> Lista()
        {
            throw new NotImplementedException();
        }

        public String NovoCadastro(Usuario usuario)
        {
            int ID_Inserido = Insere(usuario);
            if ( ID_Inserido > 0)
                return "Cadastro efetuado com sucesso";
            else
                return "Falha no cadastro";
        }

        public override Usuario MontaVO(System.Data.DataRow registro)
        {
            throw new NotImplementedException();
        }
    }
}
