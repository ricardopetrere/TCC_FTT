using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.VO
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
            throw new NotImplementedException();
        }

        public int RemoveMembro(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public int TrocarAdministrador(Usuario novo_administrador)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
