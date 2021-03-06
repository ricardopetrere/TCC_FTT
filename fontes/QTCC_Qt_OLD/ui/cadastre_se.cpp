#include "cadastre_se.h"
#include "ui_cadastre_se.h"
#include "QFileDialog"
#include "ngc/logger.h"
#include "vo/econtato.h"
#include "vo/eusuario.h"
#include <QMessageBox>

Cadastre_se::Cadastre_se(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Cadastre_se)
{
    ui->setupUi(this);
}

Cadastre_se::~Cadastre_se()
{
    delete ui;
}

void Cadastre_se::on_btnCancelar_clicked()
{
    Logger::debug("Cancelado.");
    close();
}

void Cadastre_se::on_btnCadastrar_clicked()
{
    EUsuario u;
    u.setNome(ui->lineNome->text() + " " + ui->lineSobrenome->text());
    u.setFoto(ui->lblFoto->pixmap()->toImage());
    u.setEmail(ui->lineEmail->text());
    u.setTexto_status(ui->lineTextoStatus->text());
    if(ui->lineSenha->text()!=ui->lineRepitaSenha->text())
    {
        Logger::showQMessageBox("Senhas diferentes!","Erro");
        return;
    }
    u.setSenha(ui->lineSenha->text());

    if(u.cadastraNovo())
    {
        Logger::showQMessageBox("Cadastro realizado com sucesso.","Sucesso");
        close();
    }
    else
    {
        Logger::showQMessageBox("Erro ao cadastrar","Erro");
    }
}

void Cadastre_se::on_btnEscolhaImagem_clicked()
{
    QString s = QFileDialog::getOpenFileName(this,tr("Open File"), QDir::currentPath(),"Imagens (*.jpg *.jpeg *.png *.bmp *.gif *.tif *.tiff)");
    ui->lblFoto->setPixmap(QPixmap::fromImage(QImage(s)));
    //ui->lblFoto->setScaledContents(true);
}
