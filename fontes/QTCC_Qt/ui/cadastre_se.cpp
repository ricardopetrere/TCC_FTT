#include "cadastre_se.h"
#include "ui_cadastre_se.h"
#include "QFileDialog"
#include "ngc/logger.h"

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

//Cancelar
void Cadastre_se::on_btnCancelar_clicked()
{
    Logger::debug("Cancelado.");
    close();
}

//Cadastrar
void Cadastre_se::on_btnCadastrar_clicked()
{
    Logger::debug(ui->lineNome->text(), " cadastrado.");
    return;
}

//Escolha uma imagem
void Cadastre_se::on_btnEscolhaImagem_clicked()
{
    //http://stackoverflow.com/questions/1604440/how-to-set-selected-filter-on-qfiledialog
    //QFileDialog *f = new QFileDialog(this,"Escolha uma imagem","","*.*;;*.jpg *.png;;*.jpg;;*.png");
    //f->show();
    //ui->lbl_Foto->setPixmap(QPixmap::fromImage(QImage(f->selectedFiles()[0])));
    QString s = QFileDialog::getOpenFileName(this,tr("Open File"), QDir::currentPath(),"Imagens (*.jpg *.jpeg *.png *.bmp *.gif *.tif *.tiff)");
    ui->lblFoto->setPixmap(QPixmap::fromImage(QImage(s)));
}
