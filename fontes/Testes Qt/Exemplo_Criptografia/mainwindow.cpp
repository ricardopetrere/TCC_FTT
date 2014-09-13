#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_btnApagar_clicked()
{
    ui->txtTexto->clear();
    ui->txtTexto->setFocus();
}

void MainWindow::on_btnEnviar_clicked()
{
    if(ui->txtIPDestino->text()!=new QString("")
            || ui->txtPortaDestino->text() != new QString(""))
    {

    }
}
