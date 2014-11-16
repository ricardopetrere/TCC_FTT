#include "econversa.h"

const QString EConversa::Campos::Contato = "Contato";
const QString EConversa::Campos::Mensagens = "Mensagens";

EConversa::EConversa()
{
    _contato = EContato();
    _mensagens = QList<EMensagem>();
}

EContato EConversa::contato()
{
    return _contato;
}

QList<EMensagem> EConversa::mensagens()
{
    return _mensagens;
}

QJsonObject EConversa::Serializar(EConversa &c)
{
    QJsonObject json;
    json[Campos::Contato] = c.contato().Id();
    QJsonArray mensagensArray;
    foreach (EMensagem mensagem, c.mensagens())
        mensagensArray.append(EMensagem::Serializar(mensagem));
    json[Campos::Mensagens] = mensagensArray;
    return json;
}

EConversa EConversa::Deserializar(QJsonObject &json)
{
    EConversa c;
    c._contato = EContato::busca(json[Campos::Contato].toInt());
    QJsonArray mensagemArray = json[Campos::Mensagens].toArray();
    for(int mensagemIndex = 0;mensagemIndex<mensagemArray.size();mensagemIndex++)
    {
        QJsonObject mensagemObject = mensagemArray[mensagemIndex].toObject();
        c._mensagens.append(EMensagem::Deserializar(mensagemObject));
    }
    return c;
}

void EConversa::setContato(EContato &contato)
{
    _contato = contato;
}

void EConversa::setMensagens(QList<EMensagem> &mensagens)
{
    _mensagens = mensagens;
}
