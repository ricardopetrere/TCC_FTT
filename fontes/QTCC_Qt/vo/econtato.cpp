#include <QImage>
#include <QBuffer>
#include <QByteArray>
#include "econtato.h"

const QString EContato::Campos::Nome = "Nome";
const QString EContato::Campos::Foto = "Foto";
const QString EContato::Campos::Inativo = "Inativo";

EContato::EContato() : EBase()
{
    _nome = "";
    _foto = QImage();
    _inativo=false;
}

void EContato::setNome(const QString &nome)
{
    _nome = nome;
}

const QString &EContato::Nome()
{
    return _nome;
}

void EContato::setFoto(const QImage &foto)
{
    _foto = foto;
}

const QImage &EContato::Foto()
{
    return _foto;
}

void EContato::setInativo(const bool &inativo)
{
    _inativo = inativo;
}

const bool &EContato::Inativo()
{
    return _inativo;
}

EContato EContato::busca(const int &id)
{

}

EContato EContato::Deserializar(QJsonObject &json)
{
    EContato e;
    e._id = json[EBase::Campos::ID].toInt();
    e._nome = json[Campos::Nome].toString();
    e._inativo = json[Campos::Inativo].toBool();

    QImage a;
    QByteArray array = json[Campos::Foto].toString().toLatin1();
    if(a.loadFromData(QByteArray::fromBase64(array)))
        e._foto = a;
    return e;
}

QJsonObject EContato::Serializar(EContato e)
{
    QJsonObject json;
    json[EBase::Campos::ID] = e._id;
    json[Campos::Nome] = e._nome;

    QByteArray array;
    QBuffer buffer(&array);
    buffer.open(QIODevice::WriteOnly);
    e._foto.save(&buffer,"PNG");

    json[Campos::Foto] = QString(array.toBase64(QByteArray::Base64Encoding));
    json[Campos::Inativo] = e._inativo;
    return json;
}

