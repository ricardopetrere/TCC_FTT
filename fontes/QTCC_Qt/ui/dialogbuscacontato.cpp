#include "dialogbuscacontato.h"
#include "ui_dialogbuscacontato.h"

DialogBuscaContato::DialogBuscaContato(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::DialogBuscaContato)
{
    ui->setupUi(this);
}

DialogBuscaContato::DialogBuscaContato(QString mensagem_sobre_pesquisa, QString texto_pushbutton, QString titulo, QWidget *parent) :
    DialogBuscaContato(parent)
{
    ui->lblBuscarContato->setText(mensagem_sobre_pesquisa);
    ui->btnBuscarContato->setText(texto_pushbutton);
    setWindowTitle(titulo);
}

DialogBuscaContato::~DialogBuscaContato()
{
    delete ui;
}

void DialogBuscaContato::on_btnBuscarContato_clicked()
{
    if(!ui->txtBuscarContato->text().trimmed().isEmpty())
        pesquisado = ui->txtBuscarContato->text().trimmed();
}
