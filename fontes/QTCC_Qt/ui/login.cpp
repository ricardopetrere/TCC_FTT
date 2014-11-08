#include "login.h"
#include "ui_login.h"
#include "cadastre_se.h"
#include "ngc/logger.h"
#include "vo/erequisicaologin.h"
#include "vo/eusuario.h"
#include "mainwindow.h"
#include <QCloseEvent>
#include <QMessageBox>

Login::Login(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Login)
{
    ui->setupUi(this);
    connect(ui->lineSenha,&QLineEdit::returnPressed,ui->btnLogin,&QPushButton::click);
}

int Login::login=-1;

Login::~Login()
{
    delete ui;
}
EUsuario MainWindow::_usuario_logado;
//Login
void Login::on_btnLogin_clicked()
{
    Logger::debug(ui->lineEmail->text(), " requisitando login.");
    ERequisicaoLogin login;
    login.setLogin(ui->lineEmail->text());
    login.setSenha(ui->lineSenha->text());
    MainWindow::_usuario_logado = login.requisicaoLogin();
    if(MainWindow::_usuario_logado.Id()>0)
    {
        Logger::debug(MainWindow::_usuario_logado.Nome()," logou com sucesso.");
        Login::login = MainWindow::_usuario_logado.Id();//ui->lineEmail->text();
        close();
    }
    else
    {
        Logger::debug(ui->lineEmail->text()," não encontrado.");
        Logger::showQMessageBox("Falha ao realizar login","Erro!");
    }
}

//Cadastre-se
void Login::on_btnCadastre_se_clicked()
{
    Logger::debug("Cadastre-se");
    Cadastre_se *c = new Cadastre_se(this);
    c->show();
}

void Login::closeEvent(QCloseEvent *event)
{
//    if(MainWindow::_usuario_logado.Id()>0)
//    {
//        QMessageBox *msg_sair = new QMessageBox(this);
//        msg_sair->setWindowTitle("Atenção!");
//        msg_sair->setText("Tem certeza de que deseja sair?");
//        msg_sair->setStandardButtons(QMessageBox::Yes|QMessageBox::No);
//        if(msg_sair->exec()==QMessageBox::Yes)
//            exit(0);
//    }
//    else
//    {
//       event->accept();
//       exit(0);
//    }
}
