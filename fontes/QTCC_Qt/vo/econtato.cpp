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
//Com base no objeto em JSON, retorna o EContato ao qual se refere
EContato EContato::Deserializar(QJsonObject &json)
{
    EContato c;
    c._id = json[EBase::Campos::ID].toInt();
    c._nome = json[Campos::Nome].toString();
    c._inativo = json[Campos::Inativo].toBool();
    //Deserialização dos bytes do objeto JSON (com codificação Base64) para os bytes da imagem
    QImage a;
    QByteArray array = json[Campos::Foto].toString().toLatin1();
    //Conversão dos bytes e carregamento da imagem a partir dos bytes convertidos
    //É necessário restaurar o vetor de bytes para se ter a imagem original
    if(a.loadFromData(QByteArray::fromBase64(array)))
        c._foto = a;
    return c;
}

//Com base em um EContato, retorna sua representação em JSON
QJsonObject EContato::Serializar(EContato c)
{
    QJsonObject json;
    json[EBase::Campos::ID] = c._id;
    json[Campos::Nome] = c._nome;
    //Retornar vetor de bytes da imagem
    QByteArray array;
    QBuffer buffer(&array);
    buffer.open(QIODevice::WriteOnly);
    c._foto.save(&buffer,"PNG");
    //Serialização (e conversão) dos bytes da imagem para codificação Base64
    //Essa conversão é necessária para não haver problemas com caracteres nulos na imagem
    json[Campos::Foto] = QString(array.toBase64(QByteArray::Base64Encoding));
    json[Campos::Inativo] = c._inativo;
    return json;
}

