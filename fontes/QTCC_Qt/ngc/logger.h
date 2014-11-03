#ifndef LOGGER_H
#define LOGGER_H

#include <QObject>
#include <QDate>
#include <QDebug>
#include <QMessageBox>

class Logger : public QObject
{
    Q_OBJECT
public:
    explicit Logger(QObject *parent = 0);

    //http://stackoverflow.com/a/18427241
    static void debug(QString mensagem)
    {
        qDebug(QDateTime::currentDateTime().toString().toLatin1() + ": " + mensagem.toLatin1());
    }
    static void debug(QString textoDoWidget, QString mensagem_para_concatenar)
    {
        debug(textoDoWidget.toLatin1()+mensagem_para_concatenar);
    }
    static void debug(QList<QString> listDeQStrings, QString mensagem_para_concatenar)
    {
        QString QStrings_concatenadas("");
        foreach(QString _qString, listDeQStrings)
            QStrings_concatenadas += _qString + " ";
        debug(QStrings_concatenadas,mensagem_para_concatenar);
    }
    static void showQMessageBox(QString mensagem_exibicao,QString titulo)
    {
        QMessageBox msg;
        msg.setText(mensagem_exibicao);
        msg.setWindowTitle(titulo);
        msg.show();
    }

signals:

public slots:

};

#endif // LOGGER_H
