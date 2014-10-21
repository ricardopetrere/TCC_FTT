using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TESTE_JSON
{
    [DataContract]
    public class User
    {
        [DataMember]
        public String Nome { get; set; }
        [DataMember]
        public int Idade { get; set; }

        List<Message> _mensagens = new List<Message>();
        
        [DataMember]
        public List<Message> Mensagens
        {
            get
            {
                return _mensagens;
            }
            set
            {
                _mensagens = value;
            }
        }
    }
}
