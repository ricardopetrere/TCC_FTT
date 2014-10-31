﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QTCC_Server.Util
{
    [DataContract]
    class PacoteBaseJSON
    {
        [DataMember]
        public VO.EntidadeBase Entidade { get; set; }
        
        #region TipoPacote
        //http://stackoverflow.com/a/10334951
        public VO.CONSTANTES.TiposPacotesDados TipoPacote { get; set; }
        [DataMember(Name = "TipoPacote")]
        String TipoPacote_String
        {
            get { return this.TipoPacote.ToString(); }
            set
            {
                VO.CONSTANTES.TiposPacotesDados g;
                if (Enum.TryParse(value, true, out g))
                    this.TipoPacote = g;
                else
                    throw new Util.ConversaoJSONException(TipoPacote);
            }
        }
        #endregion TipoPacote
    }
}
