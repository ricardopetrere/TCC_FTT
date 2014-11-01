#include "econtato.h"

EContato::EContato() : EBase()
{
    _nome = "";
    _foto = QImage();
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

void EContato::setFoto(QImage &foto)
{
    _foto = foto;
}

QImage &EContato::Foto()
{
    return _foto;
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
    e._id = json[Campos::IDContato].toInt();
    e._nome = json[Campos::Nome].toString();
    e._inativo = json[Campos::Inativo].toBool();
//    QImage a;
//    if(a.loadFromData(json[Campos::Foto].toString().toLatin1()))
//        e._foto = a;
    return e;
}

QJsonObject EContato::Serializar(EContato e)
{
    QJsonObject json;
    json[Campos::IDContato] = e._id;
    json[Campos::Nome] = e._nome;
    //json[Campos::Foto] = e._foto;
    json[Campos::Inativo] = e._inativo;
    return json;
}

