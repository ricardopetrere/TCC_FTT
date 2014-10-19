#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "conversas.h"
#include "login.h"
#include "ngc/logger.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    //Login::validaLogin(true,this);
    Login *l = new Login(this);
    if(!l->estaLogado())
    {
        l->setWindowModality(Qt::WindowModal);
        l->show();
    }
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_actionLogout_triggered()
{
    Logger::debug("Logout.");
    //Login::validaLogin(false,this);
    Login *l = new Login(this);
    if(l->estaLogado())
    {
        Login::realizaLogout();
        l->setWindowModality(Qt::WindowModal);
        l->show();
    }
}

void MainWindow::on_actionExibir_Conversas_triggered()
{
    Logger::debug("Exibir Conversas.");
    Conversas *c = new Conversas(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
}
