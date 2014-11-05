#include "comunicacaorede.h"
#include "ngc/logger.h"

ComunicacaoRede::ComunicacaoRede(QObject *parent) :
    QObject(parent)
{
    //connect(this,&ComunicacaoRede::connected,this,&ComunicacaoRede::)
}

QString ComunicacaoRede::enviaPacote(QString pacote)
{
    socket = new QTcpSocket(this);
    while(!(socket->state()==QAbstractSocket::ConnectedState))
    {
        socket->connectToHost("localhost",5500);
        while(!socket->waitForConnected(10000))
        {
            Logger::debug("não conseguiu");
        }
    }
    QString retorno;
    socket->write(pacote.toLatin1());
    socket->flush();
    socket->waitForBytesWritten(-1);
    socket->flush();
    //while(!socket->bytesAvailable()>0)
    while (socket->waitForReadyRead(-1))
    {
        retorno = QString(socket->readAll());
    }
    return retorno;
}
