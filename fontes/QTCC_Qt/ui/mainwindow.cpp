#include "mainwindow.h"
#include "ui_mainwindow.h"
//#include "conversas.h"
//#include "login.h"
//#include "ngc/logger.h"

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
}

void MainWindow::on_actionExibir_Conversas_triggered()
{
}
