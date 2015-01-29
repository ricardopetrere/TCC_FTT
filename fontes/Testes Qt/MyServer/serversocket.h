#ifndef SERVERSOCKET_H
#define SERVERSOCKET_H

#include <QObject>
#include <QTcpServer>
#include <QTcpSocket>
#include <QAbstractSocket>
#include <QDebug>
#include <QDate>
#include <QDateTime>

class ServerSocket : public QObject
{
    Q_OBJECT
public:
    explicit ServerSocket(QObject *parent = 0);

signals:

public slots:
    void newConnection();
    void readClient();

private:
    QTcpServer *server;
};

#endif // SERVERSOCKET_H
