#include "windowcontatos.h"
#include "ui_windowcontatos.h"

WindowContatos::WindowContatos(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowContatos)
{
    ui->setupUi(this);
}

WindowContatos::~WindowContatos()
{
    delete ui;
}

void WindowContatos::on_listContatos_itemClicked(QListWidgetItem *item)
{

}
