using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QTCC_Server.DAO;
using QTCC_Server.VO;

namespace QTCC_Server.Controller
{
    class RequisicaoLoginController : EntidadeBaseController<VO.RequisicaoLogin>
    {
        public override int Insere(VO.RequisicaoLogin entidade)
        {
            throw new NotImplementedException();
        }

        public override int Altera(VO.RequisicaoLogin entidade)
        {
            throw new NotImplementedException();
        }

        public override int Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public override VO.RequisicaoLogin Busca(int id)
        {
            throw new NotImplementedException();
        }

        public override List<VO.RequisicaoLogin> Lista()
        {
            throw new NotImplementedException();
        }
        public String RequisicaoLogin(RequisicaoLogin login)
        {
            try
            {
                return JSON_Logic.Serializa<Usuario>(RequisicaoLoginDAO.RequisicaoLogin(login));
            }
            catch
            {
                return "";
            }
        }
    }
}
