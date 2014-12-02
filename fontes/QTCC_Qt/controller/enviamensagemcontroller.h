#ifndef ENVIAMENSAGEMCONTROLLER_H
#define ENVIAMENSAGEMCONTROLLER_H

#include <QObject>
#include <QThread>

class EnviaMensagemController : public QObject
{
    Q_OBJECT
public:
    explicit EnviaMensagemController(QObject *parent = 0);
    ~EnviaMensagemController();
    QThread workerThread;
signals:
    void operate(const QString &);
public slots:
    void handleResults(const QString &);
};

#endif // ENVIAMENSAGEMCONTROLLER_H
