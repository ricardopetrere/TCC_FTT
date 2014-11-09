#include "contatowidget.h"
#include "ui_contatowidget.h"

ContatoWidget::ContatoWidget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::ContatoWidget)
{
    ui->setupUi(this);
}

ContatoWidget::~ContatoWidget()
{
    delete ui;
}
