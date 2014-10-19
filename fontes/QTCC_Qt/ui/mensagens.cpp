#include "mensagens.h"
#include "ui_mensagens.h"

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

void Mensagens::on_listWidget_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listWidget->SelectRows!=0)
        qDebug(ui->listWidget->selectedItems()[0]->text().toLatin1() + " contextMenu");
}
