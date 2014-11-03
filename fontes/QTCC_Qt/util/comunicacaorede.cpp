#include "comunicacaorede.h"
#include "ngc/logger.h"

ComunicacaoRede::ComunicacaoRede(QObject *parent) :
    QTcpSocket(parent)
{
    //connect(this,&ComunicacaoRede::connected,this,&ComunicacaoRede::)
    connectToHost("localhost",5500);
    while(!waitForConnected(-1))
    {
        Logger::debug("não conseguiu");
    }
}

QString ComunicacaoRede::enviaPacote(QString pacote)
{
    QString retorno;
    if(isOpen())
    {
        write(pacote.toLatin1());
        flush();
        waitForBytesWritten(-1);
        while (waitForReadyRead(-1)) {
            retorno = QString(readAll());
        }
    }
    else
    {

    }
    return retorno;
}
