#ifndef ENVIAMENSAGEMWORKER_H
#define ENVIAMENSAGEMWORKER_H

#include <QObject>

class EnviaMensagemWorker : public QObject
{
    Q_OBJECT
public:
    explicit EnviaMensagemWorker(QObject *parent = 0);

signals:
    void resultReady(const QString &result);
public slots:
    void doWork(const QString &parameter);
};

#endif // ENVIAMENSAGEMWORKER_H
