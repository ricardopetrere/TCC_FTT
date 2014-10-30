using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QTCC_Server.Util
{
    class TransmissaoPacotesException : Exception
    {
        public TransmissaoPacotesException(String pacote_a_processar)
            : base()
        {
            Pacote_A_Processar = pacote_a_processar;
        }
        String Pacote_A_Processar { get; set; }
    }
}
