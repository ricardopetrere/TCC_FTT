#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QFile>
#include <QJsonArray>
#include <QJsonDocument>

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
    User mUser;
    mUser.read(json);

    ui->lineNome->setText(mUser.nome());
    ui->spinIdade->setValue(mUser.idade());
    ui->textMensagens->clear();
    foreach (Message m, mUser.messages()) {
        ui->textMensagens->append(m.texto().toLatin1());
    }
}

void MainWindow::write(QJsonObject &json) const
{
    User mUser;
    mUser.setnome(ui->lineNome->text());
    mUser.setidade(ui->spinIdade->value());
    QStringList textArray = ui->textMensagens->toPlainText().split('\n');
    QList<Message> mmensagens;
    for(int textIndex=0;textIndex<textArray.size();textIndex++)
    {
        Message mMessage = Message();
        mMessage.settexto(textArray.at(textIndex));
        mmensagens.append(mMessage);
    }
    mUser.setmessages(mmensagens);

    mUser.write(json);
}

void MainWindow::on_btnSerializar_clicked()
{
    QFile saveJson("User.json");
    if(!saveJson.open(QIODevice::WriteOnly)){
        qWarning("Couldn't open User.json");
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
    QFile loadJson("User.json");
    if(!loadJson.open(QIODevice::ReadOnly)){
        qWarning("Couldn't open User.json");
        return;
    }

    QByteArray saveData = loadJson.readAll();

    QJsonDocument loadDoc(QJsonDocument::fromJson(saveData));
    read(loadDoc.object());
    qDebug("Lido.");
}
