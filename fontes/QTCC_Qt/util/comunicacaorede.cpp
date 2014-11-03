#include "comunicacaorede.h"

ComunicacaoRede::ComunicacaoRede(QObject *parent) :
    QTcpSocket(parent)
{
    //connect(this,&ComunicacaoRede::connected,this,&ComunicacaoRede::)
    connectToHost("RICARDO",5500);
    waitForConnected(-1);
}

QString ComunicacaoRede::enviaPacote(QString pacote)
{
    QString retorno;
    if(isOpen())
    {
        write(pacote.toLatin1());
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
