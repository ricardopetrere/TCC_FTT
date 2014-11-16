#include "windowmensagens.h"
#include "ui_windowmensagens.h"

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
