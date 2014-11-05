using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.VO
{
    [DataContract]
    public class EntidadeBase
    {
        #region Campos em JSON
        public static class Campos
        {
            public const string ID = "ID";
        }
        #endregion Campos em JSON
    }
}
