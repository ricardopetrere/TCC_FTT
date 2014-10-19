#include "login.h"
#include "ui_login.h"
#include "cadastre_se.h"

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
void Login::on_pushButton_clicked()
{
    qDebug("Login");
    if(ui->lineEdit->text()=="Ricardo"&&ui->lineEdit_2->text()=="Ricardo")
    {
        Login::login = ui->lineEdit->text();
        close();
    }
}

//Cadastre-se
void Login::on_pushButton_2_clicked()
{
    qDebug("Cadastre-se");
    Cadastre_se *c = new Cadastre_se(this);
    c->show();
}
