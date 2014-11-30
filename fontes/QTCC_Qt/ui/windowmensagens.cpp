#include "windowmensagens.h"
#include "ui_windowmensagens.h"

#include <util/logger.h>

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

WindowMensagens::WindowMensagens(EContato contato_destino,QWidget *parent)
    : WindowMensagens(parent)
{
    _contato_destino = contato_destino;
    ui->listMensagens->clear();
    lerMensagens();
}

void WindowMensagens::lerMensagens()
{
    foreach (EConversa conversa, ConversaController::_usuario_conversas)
    {
        if(conversa.contato().Id()==_contato_destino.Id())
        {
            foreach (EMensagem mensagem, conversa.mensagens())
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
}

void WindowMensagens::on_listMensagens_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listMensagens->itemAt(pos)!=NULL)
        Logger::debug(ui->listMensagens->itemAt(pos)->text(), " contextMenu.");
    else
        Logger::debug(windowTitle()," contextMenu");
}
