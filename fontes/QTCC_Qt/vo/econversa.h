#ifndef ECONVERSA_H
#define ECONVERSA_H

#include <QList>
#include <QJsonObject>
#include <QJsonDocument>
#include <QJsonArray>
#include <vo/emensagem.h>
#include <vo/econtato.h>

class EConversa
{
public:
    EConversa();
    EConversa* operator*(){return this;}
    void setContato(EContato &contato);
    EContato contato();
    void setMensagens(QList<EMensagem>* mensagens);
    QList<EMensagem>* mensagens();

    static QJsonObject Serializar(EConversa &c);
    static EConversa Deserializar(QJsonObject &json);
    class Campos
    {
    public:
        static const QString Contato;
        static const QString Mensagens;
    };

protected:
    EContato _contato;
    QList<EMensagem>* _mensagens;
};

#endif // ECONVERSA_H
