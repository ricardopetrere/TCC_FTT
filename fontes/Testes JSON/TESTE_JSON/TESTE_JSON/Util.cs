using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace TESTE_JSON
{
    class Util
    {
        public static String Serializa<T>(T item)
        {
            String retorno;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            System.IO.MemoryStream s = new System.IO.MemoryStream();
            serializer.WriteObject(s, item);
            retorno = Encoding.UTF8.GetString(s.ToArray());
            s.Close();
            return retorno;
        }
        public static T Deserializa<T>(String dados)
        {
            T retorno;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            System.IO.MemoryStream s = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(dados));
            retorno = (T)serializer.ReadObject(s);
            s.Close();
            return retorno;
        }
    }
}
