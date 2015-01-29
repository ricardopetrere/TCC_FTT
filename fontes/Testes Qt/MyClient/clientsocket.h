#ifndef CLIENTSOCKET_H
#define CLIENTSOCKET_H

#include <QObject>
#include <QDebug>
#include <QTcpSocket>
#include <QAbstractSocket>

class ClientSocket : public QObject
{
    Q_OBJECT
public:
    explicit ClientSocket(QObject *parent = 0);
    void Teste();
signals:

public slots:
    void	connected();
    void	disconnected();
    void    bytesWritten(qint64 bytes);
    void    readyRead();
private:
    QTcpSocket *socket;
    QString host = "localhost";
    int porta = 5500;
};

#endif // CLIENTSOCKET_H
