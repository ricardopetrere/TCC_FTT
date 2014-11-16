#include <QJsonObject>
#include <QJsonArray>
#include "eusuario.h"
//#include "econtato.h"
#include <controller/usuariocontroller.h>

const QString EUsuario::Campos::Texto_Status = "Texto_Status";
const QString EUsuario::Campos::Contatos = "Contatos";
const QString EUsuario::Campos::Email = "Email";
const QString EUsuario::Campos::Senha = "Senha";

EUsuario::EUsuario() : EContato()
{
    _texto_status = "";
    _email = "";
    _senha = "";
    _contatos = QList<EContato>();
}

EUsuario::EUsuario(EContato c)
{
    _id = c.Id();
    _nome = c.Nome();
    _foto = c.Foto();
    _inativo = c.Inativo();
    _texto_status = "";
    _email = "";
    _senha = "";
    _contatos = QList<EContato>();
}
QString EUsuario::texto_status() const
{
    return _texto_status;
}

void EUsuario::setTexto_status(const QString &texto_status)
{
    _texto_status = texto_status;
}
QList<EContato> EUsuario::contatos() const
{
    return _contatos;
}

void EUsuario::setContatos(const QList<EContato> &contatos)
{
    _contatos = contatos;
}
QString EUsuario::email() const
{
    return _email;
}

void EUsuario::setEmail(const QString &email)
{
    _email = email;
}
QString EUsuario::senha() const
{
    return _senha;
}

void EUsuario::setSenha(const QString &senha)
{
    _senha = senha;
}

EUsuario EUsuario::Deserializar(QJsonObject &json)
{
    EUsuario u(EContato::Deserializar(json));
    u._texto_status = json[Campos::Texto_Status].toString();
    u._email = json[Campos::Email].toString();
    u._senha = json[Campos::Senha].toString();
    u._contatos.clear();
    QJsonArray contatosArray = json[Campos::Contatos].toArray();
    for (int contatoIndex = 0; contatoIndex < contatosArray.size(); ++contatoIndex) {
        QJsonObject contatoObject = contatosArray[contatoIndex].toObject();
        EContato contato;
        contato = EContato::busca(contatoObject[EBase::Campos::ID].toInt());
        //contato = EContato::Deserializar(contatoObject);
        u._contatos.append(contato);
    }
    return u;
}

QJsonObject EUsuario::Serializar(EUsuario u)
{
    QJsonObject json;
    json = EContato::Serializar(u);
    json[Campos::Texto_Status] = u._texto_status;
    json[Campos::Email] = u._email;
    json[Campos::Senha] = u._senha;
    QJsonArray contatosArray;
    foreach (EContato contato, u._contatos) {
        QJsonObject contatoObject;
        contatoObject[EBase::Campos::ID] = contato.Id();
        //contatoObject = EContato::Serializar(contato);
        contatosArray.append(contatoObject);
    }
    json[Campos::Contatos] = contatosArray;
    return json;
}
