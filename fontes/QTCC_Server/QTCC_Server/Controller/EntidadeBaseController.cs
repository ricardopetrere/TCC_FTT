using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Controller
{
    public abstract class EntidadeBaseController<T>
    {

        public abstract T MontaVO(System.Data.DataRow registro)
        {
            throw new NotImplementedException();
        }

        public abstract int Insere(T entidade)
        {
            throw new NotImplementedException();
        }

        public abstract int Altera(T entidade)
        {
            throw new NotImplementedException();
        }

        public abstract int Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public abstract T Busca(int id)
        {
            throw new NotImplementedException();
        }

        public abstract List<T> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
