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
        [DataMember(Name=Campos.IDContato)]
        public int IDContato { get; set; }

        [DataMember(Name=Campos.Senha)]
        public String Senha { get; set; }
        public static class Campos
        {
            public const string IDContato = "IDContato";
            public const string Senha = "Senha";
        }
    }
}
