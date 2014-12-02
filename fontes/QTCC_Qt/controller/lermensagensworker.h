#ifndef LERMENSAGENSWORKER_H
#define LERMENSAGENSWORKER_H

#include <QObject>

class LerMensagensWorker : public QObject
{
    Q_OBJECT
public:
    explicit LerMensagensWorker(QObject *parent = 0);

signals:
    void resultReady(const QString &result);
public slots:
    void doWork(const QString &parameter);
};

#endif // LERMENSAGENSWORKER_H
