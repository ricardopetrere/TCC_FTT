#include "dialoglogin.h"
#include "ui_dialoglogin.h"
#include "dialogcadastre_se.h"

#include <vo/eusuario.h>
#include <controller/requisicaologincontroller.h>
#include <controller/usuariocontroller.h>

#include <util/logger.h>

DialogLogin::DialogLogin(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::DialogLogin)
{
    ui->setupUi(this);
    connect(ui->lineSenha,&QLineEdit::returnPressed,ui->btnLogin,&QPushButton::click);
}

DialogLogin::~DialogLogin()
{
    delete ui;
}

void DialogLogin::on_btnLogin_clicked()
{
    Logger::debug(ui->lineEmail->text(), " requisitando login.");
    ERequisicaoLogin login;
    login.setLogin(ui->lineEmail->text());
    login.setSenha(ui->lineSenha->text());
    UsuarioController::_usuario_logado = RequisicaoLoginController::requisicaoLogin(login);
    if(UsuarioController::_usuario_logado.Id()>0)
    {
        Logger::debug(UsuarioController::_usuario_logado.Nome()," logou com sucesso.");
        close();
    }
    else
    {
        Logger::debug(ui->lineEmail->text()," não encontrado.");
        Logger::showQMessageBox("Falha ao realizar login","Erro!");
    }
}

void DialogLogin::on_btnCadastre_se_clicked()
{
    Logger::debug("Cadastre-se");
    DialogCadastre_se *c = new DialogCadastre_se(this);
    c->exec();
}
