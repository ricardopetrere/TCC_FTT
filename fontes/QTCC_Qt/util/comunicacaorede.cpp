#include "comunicacaorede.h"
#include "util/logger.h"

ComunicacaoRede::ComunicacaoRede(QObject *parent) :
    QObject(parent)
{

}

//Envia o pacote recebido via rede, e retorna o que foi recebido
QString ComunicacaoRede::enviaPacote(QString pacote)
{
    socket = new QTcpSocket(this);
    //Entra em loop até conseguir se conectar com o servidor
    while(!(socket->state()==QAbstractSocket::ConnectedState))
    {
        socket->connectToHost("192.168.1.34",5500);
        //Caso não consiga, lançar log de erro
        while(!socket->waitForConnected(10000))
        {
            Logger::debug("não conseguiu");
        }
    }
    QString retorno;
    socket->write(pacote.toLatin1());
    //Espera indefinidamente até que se envie todo o pacote
    socket->waitForBytesWritten(-1);
    //Este método libera o socket para receber a resposta do servidor
    socket->flush();
    //Entra em loop até receber todo o pacote de retorno
    while (socket->waitForReadyRead(-1))
    {
        //Incrementar a variável de retorno com o que foi lido até então
        retorno += QString(socket->readAll());
    }
    //Se o pacote indicar que ocorreu erro no envio, retornar nada
    if(retorno.startsWith("Falha: "))
        return "";
    else
        return retorno;
}
