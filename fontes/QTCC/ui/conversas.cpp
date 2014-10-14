#include "conversas.h"
#include "ui_conversas.h"

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
