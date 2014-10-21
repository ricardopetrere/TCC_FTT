using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TESTE_JSON
{
    [DataContract]
    public class Message
    {
        public Message(String texto)
        {
            Texto = texto;
        }
        
        [DataMember]
        public String Texto { get; set; }
    }
}
