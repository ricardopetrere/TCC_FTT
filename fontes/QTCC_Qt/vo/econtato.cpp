#include "econtato.h"
#include <QImage>
#include <QBuffer>
#include <QByteArray>

//const QString EContato::Campos::IDContato = EBase::Campos::ID;
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
    if(a.loadFromData(json[Campos::Foto].toString().toLatin1()))
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
    QByteArray::Format f = QImage::format();
    e._foto.save(&buffer,"JPEG");

    QByteArray s1 = QByteArray((char*)e._foto.bits(),e._foto.byteCount());

    QString s2 = array.toBase64(QByteArray::Base64Encoding);

    QString s3 = e._foto.

    //QByteArray array((char*)e._foto.bits(),e._foto.byteCount());
    json[Campos::Foto] = QString::fromLocal8Bit(array);
    json[Campos::Inativo] = e._inativo;
    return json;
}

