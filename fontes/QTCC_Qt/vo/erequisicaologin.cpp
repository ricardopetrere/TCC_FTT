#include "erequisicaologin.h"
#include "controller/requisicaologincontroller.h"
#include "eusuario.h"

const QString ERequisicaoLogin::Campos::Login = "Login";
const QString ERequisicaoLogin::Campos::Senha = "Senha";

ERequisicaoLogin::ERequisicaoLogin()
{
    _login = "";
    _senha = "";
}

EUsuario ERequisicaoLogin::requisicaoLogin()
{
    return RequisicaoLoginController::requisicaoLogin(*this);
}
QString ERequisicaoLogin::login() const
{
    return _login;
}

void ERequisicaoLogin::setLogin(const QString &login)
{
    _login = login;
}
QString ERequisicaoLogin::senha() const
{
    return _senha;
}

void ERequisicaoLogin::setSenha(const QString &senha)
{
    _senha = senha;
}

ERequisicaoLogin ERequisicaoLogin::Deserializar(QJsonObject &json)
{
    ERequisicaoLogin retorno;
    retorno._login = json[Campos::Login].toString();
    retorno._senha = json[Campos::Senha].toString();
    return retorno;
}

QJsonObject ERequisicaoLogin::Serializar(ERequisicaoLogin l)
{
    QJsonObject json;
    json[Campos::Login] = l._login;
    json[Campos::Senha] = l._senha;
    return json;
}


