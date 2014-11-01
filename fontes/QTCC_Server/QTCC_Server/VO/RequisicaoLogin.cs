using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    public class RequisicaoLogin
    {
        #region Propriedades
        #region Login
        [DataMember(Name = Campos.Login)]
        public int Login { get; set; }
        #endregion Login

        #region Senha
        [DataMember(Name = Campos.Senha)]
        public String Senha { get; set; } 
        #endregion
        #endregion Propriedades

        #region Campos em JSON
        public static class Campos
        {
            public const string Login = "Login";
            public const string Senha = "Senha";
        }
        #endregion Campos em JSON
    }
}
