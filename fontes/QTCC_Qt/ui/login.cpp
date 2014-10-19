#include "login.h"
#include "ui_login.h"
#include "cadastre_se.h"
#include "ngc/logger.h"

Login::Login(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Login)
{
    ui->setupUi(this);
}

QString Login::login="";

Login::~Login()
{
    delete ui;
}

//Login
void Login::on_btnLogin_clicked()
{
    Logger::debug("Login");
    if(ui->lineEmail->text()=="admin"&&ui->lineSenha->text()=="admin")
    {
        Login::login = ui->lineEmail->text();
        close();
    }
}

//Cadastre-se
void Login::on_btnCadastre_se_clicked()
{
    Logger::debug("Cadastre-se");
    Cadastre_se *c = new Cadastre_se(this);
    c->show();
}
