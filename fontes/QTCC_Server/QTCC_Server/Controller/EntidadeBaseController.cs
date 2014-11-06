using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Controller
{
    public abstract class EntidadeBaseController<T>
    {
        public abstract T MontaVO(System.Data.DataRow registro);

        public abstract int Insere(T entidade);

        public abstract int Altera(T entidade);

        public abstract int Exclui(int id);

        public abstract T Busca(int id);

        public abstract List<T> Lista();
    }
}
