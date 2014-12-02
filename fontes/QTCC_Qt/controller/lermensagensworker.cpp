#include "lermensagensworker.h"
#include "mensagemcontroller.h"
#include "conversacontroller.h"

LerMensagensWorker::LerMensagensWorker(QObject *parent) :
    QObject(parent)
{
}

void LerMensagensWorker::doWork(const QString &parameter)
{
    QString result;
    while(true)
    {
        QList<EMensagem> mensagens = MensagemController::ReceberNovasMensagens();
        QList<EConversa>* conversas = new QList<EConversa>;
        conversas = ConversaController::_usuario_conversas;
        bool achouConversa;
        for(int a = 0;a<mensagens.size();a++)
        {
            achouConversa = false;
            for(int b = 0;b<conversas->size();b++)
            {
                if((*conversas)[b].contato().Id()==mensagens[a].Contato_De().Id())
                {
                    achouConversa = true;
                    (*conversas)[b].mensagens()->append(mensagens[a]);
                    break;
                }
            }
            //Se não achou conversa para aquela mensagem, cria nova conversa
            if(!achouConversa)
            {
                EConversa c;
                EContato cont_de = mensagens[a].Contato_De();
                c.setContato(cont_de);
                c.mensagens()->append(mensagens[a]);
                conversas->append(c);
            }
        }
        //Não há sentido em sobrecarregar esse processo.
        if(mensagens.size()>0)
            ConversaController::salvarConversasUsuarioLogado();
        emit resultReady(result);
    }
}
