#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileDialog>
#include <QJsonObject>
#include <QJsonDocument>
#include <QBuffer>
#include <QByteArray>

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

void MainWindow::read(const QJsonObject &json)
{
    QImage a;
    QByteArray array = json["Foto"].toString().toLatin1();
    if(a.loadFromData(QByteArray::fromBase64(array)))
        ui->lblFoto->setPixmap(QPixmap::fromImage(a));
}

void MainWindow::write(QJsonObject &json) const
{
    QByteArray array;
    QBuffer buffer(&array);
    buffer.open(QIODevice::WriteOnly);
    QImage a (ui->lblFoto->pixmap()->toImage());
    a.save(&buffer,"PNG");

    QString s2 = array.toBase64(QByteArray::Base64Encoding);

    QByteArray s3 = buffer.data();

    QString s = QString::fromUtf8(array);
    json["Foto"] = s2;
}

//Escolher foto
void MainWindow::on_btnEscolherImagem_clicked()
{
    QString s = QFileDialog::getOpenFileName(this,tr("Open File"), QDir::currentPath(),"Imagens (*.jpg *.jpeg *.png *.bmp *.gif *.tif *.tiff)");
    ui->lblFoto->setPixmap(QPixmap::fromImage(QImage(s)));
}

void MainWindow::on_btnSerializar_clicked()
{
    QFile saveJson("Imagem.json");
    if(!saveJson.open(QIODevice::WriteOnly)){
        qWarning("Couldn't open Imagem.json");
        return;
    }

    QJsonObject jsonObject;
    write(jsonObject);
    QJsonDocument saveDoc(jsonObject);
    saveJson.write(saveDoc.toJson());
    qDebug("Salvo.");
}

void MainWindow::on_btnDeserializar_clicked()
{
    QFile loadJson("Imagem.json");
    if(!loadJson.open(QIODevice::ReadOnly)){
        qWarning("Couldn't open Imagem.json");
        return;
    }

    QByteArray saveData = loadJson.readAll();

    QJsonDocument loadDoc(QJsonDocument::fromJson(saveData));
    read(loadDoc.object());
    qDebug("Lido.");
}
