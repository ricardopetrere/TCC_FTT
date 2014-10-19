#include "conversas.h"
#include "ui_conversas.h"
#include "contatos.h"
#include "mensagens.h"

Conversas::Conversas(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Conversas)
{
    ui->setupUi(this);
}

Conversas::~Conversas()
{
    delete ui;
}

void Conversas::on_listWidget_itemClicked(QListWidgetItem *item)
{
    qDebug(item->text().toLatin1() + " Clicado.");
    Mensagens *m = new Mensagens(this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void Conversas::on_actionNova_Conversa_triggered()
{
    Contatos *c = new Contatos(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
}

void Conversas::on_listWidget_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listWidget->SelectRows!=0)
        qDebug(ui->listWidget->selectedItems()[0]->text().toLatin1() + " contextMenu");
}
