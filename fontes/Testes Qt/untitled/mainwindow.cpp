#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "QMessageBox"
#include "QFormLayout"
#include "QWidget"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_btnExibir_clicked()
{
    if(ui->txtNome->text().length() == 0 || ui->txtEmail->text().length() == 0 || ui->spinBoxIdade->value() == 0)
    {
        QMessageBox MsgBox;
        MsgBox.setText("Favor preencher os campos!");
        MsgBox.exec();
    }
    else
    {
        ui->textEdit->setText("Nome: " + ui->txtNome->text() + "\nEmail: " + ui->txtEmail->text() +
                          "\nIdade: " + ui->spinBoxIdade->text() + " anos");
    }
}

void MainWindow::on_btnLimpar_clicked()
{
    ui->txtNome->clear();
    ui->txtEmail->clear();
    ui->spinBoxIdade->clear();
    ui->textEdit->clear();
}
