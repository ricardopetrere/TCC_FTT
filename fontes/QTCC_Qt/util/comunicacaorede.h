#ifndef COMUNICACAOREDE_H
#define COMUNICACAOREDE_H

#include <QTcpSocket>

class ComunicacaoRede : public QTcpSocket
{
    Q_OBJECT
public:
    explicit ComunicacaoRede(QObject *parent = 0);
    QString enviaPacote(QString pacote);
signals:

public slots:

};

#endif // COMUNICACAOREDE_H
