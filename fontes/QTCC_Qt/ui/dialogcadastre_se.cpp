#include "dialogcadastre_se.h"
#include "ui_dialogcadastre_se.h"

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

}

void DialogCadastre_se::on_btnCancelar_clicked()
{

}

void DialogCadastre_se::on_btnCadastrar_clicked()
{

}
