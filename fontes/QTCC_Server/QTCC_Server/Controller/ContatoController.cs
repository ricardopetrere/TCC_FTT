using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Controller
{
    class ContatoController : EntidadeBaseController<VO.Contato>
    {
        public override VO.Contato MontaVO(System.Data.DataRow registro)
        {
            throw new NotImplementedException();
        }

        public override int Insere(VO.Contato entidade)
        {
            throw new NotImplementedException();
        }

        public override int Altera(VO.Contato entidade)
        {
            throw new NotImplementedException();
        }

        public override int Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public override VO.Contato Busca(int id)
        {
            throw new NotImplementedException();
        }

        public override List<VO.Contato> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
