#include "enviamensagemcontroller.h"
#include "enviamensagemworker.h"

EnviaMensagemController::EnviaMensagemController(QObject *parent) :
    QObject(parent)
{
    EnviaMensagemWorker *worker = new EnviaMensagemWorker;
    worker->moveToThread(&workerThread);
    connect(&workerThread,&QThread::finished,worker,&QObject::deleteLater);
    connect(this,&EnviaMensagemController::operate,worker,&EnviaMensagemWorker::doWork);
    connect(worker,&EnviaMensagemWorker::resultReady,this,&EnviaMensagemController::handleResults);
    workerThread.start();
}

EnviaMensagemController::~EnviaMensagemController()
{
    workerThread.quit();
    workerThread.exit();
}

void EnviaMensagemController::handleResults(const QString &)
{

}
