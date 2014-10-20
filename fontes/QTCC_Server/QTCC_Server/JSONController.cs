using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using QTCC_Server.CS;

namespace QTCC_Server
{
    public static class JSONController
    {
        //http://msdn.microsoft.com/en-us/library/bb412179(VS.100).aspx
        public static T DeserializaJSON<T>(String dados_json) where T:EntidadeBase,new()
        {
            T objeto = new T();
            MemoryStream s = new MemoryStream(Encoding.UTF8.GetBytes(dados_json));
            DataContractJsonSerializer json_serializer = new DataContractJsonSerializer(objeto.GetType());
            objeto = (T)json_serializer.ReadObject(s);
            s.Close();
            return objeto;
        }

        public static String SerializaJSON(EntidadeBase objeto)
        {
            DataContractJsonSerializer json_serializer = new DataContractJsonSerializer(objeto.GetType());
            MemoryStream s = new System.IO.MemoryStream();
            json_serializer.WriteObject(s, objeto);
            String retorno = Encoding.UTF8.GetString(s.ToArray());
            s.Close();
            return retorno;
        }
    }
}
