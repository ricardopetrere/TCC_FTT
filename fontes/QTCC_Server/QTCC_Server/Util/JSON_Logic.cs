using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

public class JSON_Logic
{
    /// <summary>
    /// Serializa um objeto qualquer para JSON
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser serializado</typeparam>
    /// <param name="item">O objeto a ser serializado</param>
    /// <returns>A representação do objeto em JSON</returns>
    public static String Serializa<T>(T item)
    {
        String retorno;
        //Define o serializador para o tipo do objeto passado
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
        MemoryStream s = new MemoryStream();
        try
        {
            //Serializa o objeto em JSON, e envia seus bytes para "s"
            serializer.WriteObject(s, item);
            //Retorna os bytes em String
            retorno = Encoding.UTF8.GetString(s.ToArray());
        }
        finally
        {
            //Fecha o buffer de "s"
            s.Close();
        }
        return retorno;
    }
    /// <summary>
    /// Deserializa um JSON para qualquer objeto
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser gerado</typeparam>
    /// <param name="dados">O objeto em JSON</param>
    /// <returns>O objeto gerado</returns>
    public static T Deserializa<T>(String dados)
    {
        T retorno;
        //Define o serializador para o tipo do objeto a retornar
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        //Instancia "s" já preenchendo-o com os bytes do JSON passado
        MemoryStream s = new MemoryStream(Encoding.UTF8.GetBytes(dados));
        try
        {
            //Lê os bytes contidos em "s" e retorna o objeto do tipo "T"
            retorno = (T)serializer.ReadObject(s);
        }
        finally
        {
            //Fecha o buffer de "s"
            s.Close();
        }
        return retorno;
    }
}