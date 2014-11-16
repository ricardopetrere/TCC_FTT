#include "mensagens.h"
#include "ui_mensagens.h"
#include "ngc/logger.h"

Mensagens::Mensagens(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Mensagens)
{
    ui->setupUi(this);
}

Mensagens::~Mensagens()
{
    delete ui;
}

void Mensagens::on_listMensagens_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listMensagens->SelectRows!=0)
        Logger::debug(ui->listMensagens->selectedItems()[0]->text()," contextMenu.");
}

void Mensagens::on_btnEnviar_clicked()
{
    Logger::debug(ui->textMensagem->toPlainText()," Enviado.");
}
