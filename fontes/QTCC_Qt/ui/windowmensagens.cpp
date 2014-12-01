#include "windowmensagens.h"
#include "ui_windowmensagens.h"
#include <QThread>

#include <util/logger.h>
#include <controller/mensagemcontroller.h>

WindowMensagens::WindowMensagens(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowMensagens)
{
    ui->setupUi(this);
}

WindowMensagens::~WindowMensagens()
{
    delete ui;
}

WindowMensagens::WindowMensagens(EConversa *conversa, QWidget *parent)
    : WindowMensagens(parent)
{
    _conversa = conversa;
    ui->listMensagens->clear();
    lerMensagens();
}

void WindowMensagens::lerMensagens()
{
    foreach (EConversa conversa, *ConversaController::_usuario_conversas)
    {
        if(conversa.contato().Id()==_conversa->contato().Id())
        {
            foreach (EMensagem mensagem, *conversa.mensagens())
            {
                QListWidgetItem* itm_Mensagem = new QListWidgetItem(ui->listMensagens);
                itm_Mensagem->setText(QString(mensagem.Dados()));
                itm_Mensagem->setBackground(QBrush(Qt::SolidPattern));
                if(mensagem.Contato_De().Id()==UsuarioController::_usuario_logado.Id())
                {
                    switch (mensagem.Status_Envio())
                    {
                    case Constantes::DestinatarioRecebeu:
                        itm_Mensagem->setBackgroundColor(cor_RecebidoNoDestino);
                        break;
                    case Constantes::EnviadoAoServidor:
                        itm_Mensagem->setBackgroundColor(cor_Enviado);
                        break;
                    case Constantes::EntregaPendente:
                        itm_Mensagem->setBackgroundColor(cor_EntregaPendente);
                        break;
                    }
                }
                else
                {
                    itm_Mensagem->setBackgroundColor(cor_Recebido);
                }
                itm_Mensagem->setTextAlignment(Qt::AlignRight);
                itm_Mensagem->setFont(QFont("Segoe UI",12));
                ui->listMensagens->addItem(itm_Mensagem);
            }
            break;
        }
    }
}

void WindowMensagens::on_btnEnviar_clicked()
{
    QListWidgetItem* itm_Mensagem = new QListWidgetItem(ui->listMensagens);
    itm_Mensagem->setText(ui->textMensagem->toPlainText());
    itm_Mensagem->setBackground(QBrush(Qt::SolidPattern));
    itm_Mensagem->setBackgroundColor(cor_EntregaPendente);
    itm_Mensagem->setTextAlignment(Qt::AlignRight);
    itm_Mensagem->setFont(QFont("Segoe UI",12));
    ui->listMensagens->addItem(itm_Mensagem);

	//Se enviou a mensagem, apagar da txt
	ui->textMensagem->clear();
    //Enviar para o servidor
    EMensagem m;
    EContato usuario_atual = UsuarioController::_usuario_logado;
    m.setContato_De(usuario_atual);
    EContato temp2 = _conversa->contato();
    m.setContato_Para(temp2);
    QByteArray texto(itm_Mensagem->text().toLatin1());
    m.setDados(texto);
    QDateTime data_atual = QDateTime::currentDateTime();
    m.setData_Envio(data_atual);
    Constantes::EStatusEnvioEnum status = Constantes::EntregaPendente;
    m.setStatus_Envio(status);
    Constantes::ETipoMensagemEnum tipo = Constantes::Texto;
    m.setTipo_Mensagem(tipo);
    if(enviarMensagemParaServidor(m))
    {
        status = Constantes::EnviadoAoServidor;
        m.setStatus_Envio(status);
        itm_Mensagem->setBackgroundColor(cor_Enviado);
    }
    QList<EMensagem>* mensagens = _conversa->mensagens();
    mensagens->append(m);
    _conversa->setMensagens(mensagens);
    ConversaController::salvarConversasUsuarioLogado();
//    QThread t(this);
//    t.setEventDispatcher(enviarMensagemParaServidor(m));
//    t.start();
}
bool WindowMensagens::enviarMensagemParaServidor(EMensagem m)
{
    return MensagemController::EnviarNovaMensagem(m);
}

void WindowMensagens::on_listMensagens_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listMensagens->itemAt(pos)!=NULL)
        Logger::debug(ui->listMensagens->itemAt(pos)->text(), " contextMenu.");
    else
        Logger::debug(windowTitle()," contextMenu");
}
