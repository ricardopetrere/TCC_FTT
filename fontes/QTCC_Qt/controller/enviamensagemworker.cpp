#include "enviamensagemworker.h"

EnviaMensagemWorker::EnviaMensagemWorker(QObject *parent) :
    QObject(parent)
{
}

void EnviaMensagemWorker::doWork(const QString &parameter)
{
    QString result;

    emit resultReady(result);
}
