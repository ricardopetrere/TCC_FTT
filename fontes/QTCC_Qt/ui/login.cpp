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

//QString Login::login="-1";
int Login::login=-1;
//QString Login::login=NULL;

Login::~Login()
{
    delete ui;
}

//Login
void Login::on_btnLogin_clicked()
{
    Logger::debug(ui->lineEmail->text(), " requisitando login.");
    if(ui->lineEmail->text()=="admin"&&ui->lineSenha->text()=="admin")
    {
        Logger::debug(ui->lineEmail->text()," logou com sucesso.");
        Login::login = 0;//ui->lineEmail->text();
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
