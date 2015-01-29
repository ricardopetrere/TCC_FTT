#include "clientsocket.h"

ClientSocket::ClientSocket(QObject *parent) :
    QObject(parent)
{
    //Teste();
}

void ClientSocket::Teste()
{
    socket = new QTcpSocket(this);
    connect(socket,SIGNAL(connected()),this,SLOT(connected()));
    connect(socket,SIGNAL(disconnected()),this,SLOT(disconnected()));
    connect(socket,SIGNAL(readyRead()),this,SLOT(readyRead()));
    connect(socket,SIGNAL(bytesWritten(qint64)),this,SLOT(bytesWritten(qint64)));

    qDebug() << "Conectando...";

    while(!(socket->state()==QAbstractSocket::ConnectedState))
    {
        socket->connectToHost(host,porta);
        if(!socket->waitForConnected(10000))
        {
            qDebug() << "Erro: " << socket->errorString() << "Tentando novamente...";
        }
    }
}

void ClientSocket::connected()
{
    qDebug() << "Conectado";
    QString mensagem("Good day, sir!");
    qDebug() << "Enviando" << mensagem.toLatin1();
    socket->write(mensagem.toLatin1());
    socket->flush();
    socket->waitForBytesWritten();
}

void ClientSocket::disconnected()
{
    qDebug() << "Disconectado!";
    socket->close();
    exit(0);
}

void ClientSocket::bytesWritten(qint64 bytes)
{
    qDebug() << "Escrevendo" << bytes << "bytes";
}

void ClientSocket::readyRead()
{
    qDebug() << "Recebendo...";
    qDebug() << socket->readAll();
}
