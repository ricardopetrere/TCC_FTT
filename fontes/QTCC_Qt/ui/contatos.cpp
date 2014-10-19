#include "contatos.h"
#include "ui_contatos.h"
#include "mensagens.h"

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

void Contatos::on_listWidget_itemClicked(QListWidgetItem *item)
{
    qDebug(item->text().toLatin1() + " Clicado.");
    Mensagens *m = new Mensagens(this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void Contatos::on_listWidget_itemDoubleClicked(QListWidgetItem *item)
{

}

void Contatos::on_listWidget_itemPressed(QListWidgetItem *item)
{

}

void Contatos::on_listWidget_customContextMenuRequested(const QPoint &pos)
{
    //http://stackoverflow.com/a/18427241
    if(ui->listWidget->SelectRows!=0)
        qDebug(ui->listWidget->selectedItems()[0]->text().toLatin1() + " contextMenu");
}

void Contatos::on_listWidget_clicked(const QModelIndex &index)
{

}
