#include "contatos.h"
#include "ui_contatos.h"
#include "mensagens.h"
#include "ngc/logger.h"

Contatos::Contatos(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Contatos)
{
    ui->setupUi(this);
}

Contatos::~Contatos()
{
    delete ui;
}

void Contatos::on_listContatos_itemClicked(QListWidgetItem *item)
{
    Logger::debug(item->text(), " Clicado.");
    Mensagens *m = new Mensagens(this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void Contatos::on_listContatos_itemDoubleClicked(QListWidgetItem *item)
{
    Logger::debug("on_listContatos_itemDoubleClicked");
}

void Contatos::on_listContatos_itemPressed(QListWidgetItem *item)
{
    Logger::debug("on_listContatos_itemPressed");
}

void Contatos::on_listContatos_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listContatos->SelectRows!=0)
        Logger::debug(ui->listContatos->selectedItems()[0]->text(), " contextMenu.");
}

void Contatos::on_listContatos_clicked(const QModelIndex &index)
{
    Logger::debug("on_listContatos_clicked");
}
