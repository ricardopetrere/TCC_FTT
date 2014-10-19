#include "conversas.h"
#include "ui_conversas.h"
#include "contatos.h"
#include "mensagens.h"
#include "ngc/logger.h"

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

void Conversas::on_listConversas_itemClicked(QListWidgetItem *item)
{
    Logger::debug(item->text(), " Clicado.");
    Mensagens *m = new Mensagens(this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void Conversas::on_actionNova_Conversa_triggered()
{
    Logger::debug("Nova Conversa.");
    Contatos *c = new Contatos(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
}

void Conversas::on_listConversas_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listConversas->SelectRows!=0)
        Logger::debug(ui->listConversas->selectedItems()[0]->text(), " contextMenu.");
}
