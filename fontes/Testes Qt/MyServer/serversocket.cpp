#include "serversocket.h"

ServerSocket::ServerSocket(QObject *parent) :
    QObject(parent)
{
    server = new QTcpServer(this);
    connect(server,SIGNAL(newConnection()),this,SLOT(newConnection()));
    connect(server,SIGNAL(newConnection()),this,SLOT(readClient()));

    if(!server->listen(QHostAddress::Any,8733))
    {
        qDebug() << "Servidor não iniciado!";
    }
    else
    {
        qDebug() << "Servidor iniciado!";
    }
}

void ServerSocket::newConnection()
{
//    QTcpSocket *socket = server->nextPendingConnection();
//    socket->write("Buon giorno\r\n");
//    socket->flush();
//    socket->waitForBytesWritten(3000);
//    socket->close();
}

void ServerSocket::readClient()
{
    QTcpSocket *tcpSocket = server->nextPendingConnection();
    tcpSocket->waitForReadyRead();
    QString a(tcpSocket->readAll());
    qDebug() << "Recebido:" << a;
//    QDate date;
//    QString name;
//    QDateTime tempo;
//    QDataStream in(tcpSocket);
//    in.setVersion(QDataStream::Qt_5_3);
//    in >> date >> name >> tempo;
//    qDebug() << "date: " << date.day() << "Nome: " << name << "Hora: " << tempo;
    qDebug() << "Enviando resposta...";
    tcpSocket->write("Buon Giorno");
    tcpSocket->flush();
    tcpSocket->waitForBytesWritten();
    tcpSocket->close();

}
