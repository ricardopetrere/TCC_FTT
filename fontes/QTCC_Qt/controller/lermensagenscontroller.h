#ifndef LERMENSAGENSCONTROLLER_H
#define LERMENSAGENSCONTROLLER_H

#include <QObject>
#include <QThread>

class LerMensagensController : public QObject
{
    Q_OBJECT
public:
    explicit LerMensagensController(QObject *parent = 0);
    ~LerMensagensController();
    QThread workerThread;
signals:
    void operate(const QString &);
public slots:
    void handleResults(const QString &);
};

#endif // LERMENSAGENSCONTROLLER_H
