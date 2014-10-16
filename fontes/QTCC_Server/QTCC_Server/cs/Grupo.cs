using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.CS
{
    class Grupo : Contato
    {
        #region Propriedades
        public List<Usuario> Membros
        {
            get;
            set;
        }
        public Usuario Administrador
        {
            get;
            set;
        }
        #endregion
        #region Métodos
        public Grupo()
            : base()
        {
            Membros = new List<Usuario>();
            Administrador = new Usuario();
        }
        

        public int AdicionaMembro(Usuario usuario)
        {

        }

        public int RemoveMembro(Usuario usuario)
        {

        }

        public int TrocarAdministrador(Usuario novo_administrador)
        {

        }
        #endregion
    }
}
