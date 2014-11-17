#include "dialogcadastre_se.h"
#include "ui_dialogcadastre_se.h"

#include <controller/usuariocontroller.h>

#include <util/logger.h>

#include <QFileDialog>

DialogCadastre_se::DialogCadastre_se(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::DialogCadastre_se)
{
    ui->setupUi(this);
}

DialogCadastre_se::~DialogCadastre_se()
{
    delete ui;
}

void DialogCadastre_se::on_btnEscolhaImagem_clicked()
{
    QString s = QFileDialog::getOpenFileName(this,tr("Open File"), QDir::currentPath(),"Imagens (*.jpg *.jpeg *.png *.bmp *.gif *.tif *.tiff)");
    ui->lblFoto->setPixmap(QPixmap::fromImage(QImage(s)));
}

void DialogCadastre_se::on_btnCancelar_clicked()
{
    Logger::debug("Cancelado.");
    close();
}

void DialogCadastre_se::on_btnCadastrar_clicked()
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

    if(UsuarioController::cadastraNovo(u))
    {
        Logger::showQMessageBox("Cadastro realizado com sucesso.","Sucesso");
        close();
    }
    else
    {
        Logger::showQMessageBox("Erro ao cadastrar","Erro");
    }
}
