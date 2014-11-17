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

}

void WindowMensagens::on_listMensagens_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listMensagens->itemAt(pos)!=NULL)
        Logger::debug(ui->listMensagens->itemAt(pos)->text(), " contextMenu.");
    else
        Logger::debug(windowTitle()," contextMenu");
}
