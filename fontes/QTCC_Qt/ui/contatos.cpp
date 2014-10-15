#include "contatos.h"
#include "ui_contatos.h"

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
