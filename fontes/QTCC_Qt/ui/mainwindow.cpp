#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "conversas.h"
#include "login.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    Login::validaLogin(true,this);
//    Login *l = new Login(this);
//    if(!l->estaLogado())
//    {
//        l->setWindowModality(Qt::WindowModal);
//        l->show();
//    }
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_actionLogout_triggered()
{
    Login::validaLogin(false,this);
//    Login *l = new Login(this);
//    if(l->estaLogado())
//    {
//        l->setWindowModality(Qt::WindowModal);
//        l->show();
//    }
}

void MainWindow::on_actionExibir_Conversas_triggered()
{
    Conversas *c = new Conversas(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
    //this->hide();
}
