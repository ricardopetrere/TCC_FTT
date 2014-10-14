#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "conversas.h"

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

void MainWindow::on_actionLogout_triggered()
{
    exit(0);
}

void MainWindow::on_actionExibir_Conversas_triggered()
{
    Conversas *c = new Conversas(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
    this->hide();
}
