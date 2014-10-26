#include "econtato.h"

EContato::EContato() : EBase()
{
    _nome = "";
    _imagem = QImage();
    _inativo=false;
}

void EContato::setNome(QString &nome)
{
    _nome = nome;
}

QString &EContato::Nome()
{
    return _nome;
}

void EContato::setImage(QImage &imagem)
{
    _imagem = imagem;
}

QImage &EContato::Imagem()
{
    return _imagem;
}

void EContato::setInativo(bool &inativo)
{
    _inativo = inativo;
}

bool &EContato::Inativo()
{
    return _inativo;
}

EContato EContato::Deserializar(QJsonObject &json)
{
    EContato e;
    e._id = json["Id"].toInt();
    e._nome = json["Nome"].toString();
    e._inativo = json["Inativo"].toBool();
//    QImage a;
//    if(a.loadFromData(json["Imagem"].toString().toLatin1()))
//        e._imagem = a;
    return e;
}

QJsonObject EContato::Serializar(EContato e)
{
    QJsonObject json;
    json["Id"] = e._id;
    json["Nome"] = e._nome;
    //json["Imagem"] = e._imagem;
    json["Inativo"] = e._inativo;
    return json;
}

