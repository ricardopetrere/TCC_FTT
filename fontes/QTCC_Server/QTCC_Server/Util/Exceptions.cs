using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace QTCC_Server.Util
{
    class BaseException : Exception
    {
        public BaseException() : base() { }
        public BaseException(String mensagem) : base(mensagem) { }
    }
    class TransmissaoPacotesException : BaseException
    {
        public TransmissaoPacotesException(String pacote_a_processar)
            : base("Erro ao processar o seguinte pacote:" + Environment.NewLine + pacote_a_processar) 
        {
            Pacote_A_Processar = pacote_a_processar;
        }
        String Pacote_A_Processar { get; set; }
    }
    class ConversaoJSONException : BaseException
    {
        public ConversaoJSONException(object elemento)
            : base("Erro ao serializar/deserializar o seguinte elemento:" + Environment.NewLine + elemento.ToString())
        {
            Elemento = elemento;
        }
        object Elemento { get; set; }
    }
}
