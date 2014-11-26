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

void WindowMensagens::on_btnEnviar_clicked()
{
    QListWidgetItem* itm_Mensagem = new QListWidgetItem(ui->listMensagens);
    itm_Mensagem->setText(ui->textMensagem->toPlainText());
//    itm_Mensagem.setBackgroundColor(QColor::fromRgb(221,221,221));//Recebido
    itm_Mensagem->setBackground(QBrush(Qt::SolidPattern));
    itm_Mensagem->setBackgroundColor(QColor::fromRgb(178,248,157));//Enviado
    itm_Mensagem->setTextAlignment(Qt::AlignRight);
    itm_Mensagem->setFont(QFont("Segoe UI",12));
    ui->listMensagens->addItem(itm_Mensagem);
}

void WindowMensagens::on_listMensagens_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listMensagens->itemAt(pos)!=NULL)
        Logger::debug(ui->listMensagens->itemAt(pos)->text(), " contextMenu.");
    else
        Logger::debug(windowTitle()," contextMenu");
}
