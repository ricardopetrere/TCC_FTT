#include "lermensagenscontroller.h"
#include "lermensagensworker.h"

LerMensagensController::LerMensagensController(QObject *parent) :
    QObject(parent)
{
    LerMensagensWorker *worker = new LerMensagensWorker;
    worker->moveToThread(&workerThread);
    connect(&workerThread,&QThread::finished,worker,&QObject::deleteLater);
    connect(this,&LerMensagensController::operate,worker,&LerMensagensWorker::doWork);
    connect(worker,&LerMensagensWorker::resultReady,this,&LerMensagensController::handleResults);
    workerThread.start();
}

LerMensagensController::~LerMensagensController()
{
    if(workerThread.isRunning())
        workerThread.quit();
}

void LerMensagensController::handleResults(const QString &)
{

}
