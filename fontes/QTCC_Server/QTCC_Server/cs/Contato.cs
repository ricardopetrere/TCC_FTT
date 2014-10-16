using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QTCC_Server.CS
{
    class Contato
    {
        #region Propriedades
        private int Id
        {
            get;
            set;
        }

        public String Nome
        {
            get;
            set;
        }

        public Image Foto
        {
            get;
            set;
        }

        private Boolean Inativo
        {
            get;
            set;
        }
        #endregion
        #region Métodos
        public Contato()
        {
            Id = -1;
            Nome = "";
            Foto = null;
            Inativo = false;
        }

        public static Contato MontaVO(System.Data.DataRow registro)
        {

        }

        public static int InsereContato(Contato contato)
        {

        }

        public static int AlteraContato(Contato contato)
        {

        }

        public static int ExcluiContato(int id_contato)
        {

        }

        public static Contato BuscaContato(int id_contato)
        {

        }
        #endregion
    }
}
