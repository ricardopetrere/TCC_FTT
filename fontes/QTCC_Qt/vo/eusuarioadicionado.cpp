#include "eusuarioadicionado.h"
#include "controller/usuariocontroller.h"

const QString EUsuarioAdicionado::Campos::NovoUsuario = "NovoUsuario";

EUsuarioAdicionado::EUsuarioAdicionado()
{
    _novousuario = EUsuario();
}

int EUsuarioAdicionado::IdContato() const
{
    return _id;
}

void EUsuarioAdicionado::setIdContato(const int &id_contato)
{
    _id = id_contato;
}

EUsuario EUsuarioAdicionado::NovoUsuario() const
{
    return _novousuario;
}

void EUsuarioAdicionado::setNovoUsuario(const EUsuario &novousuario)
{
    _novousuario = novousuario;
}

EUsuarioAdicionado EUsuarioAdicionado::Deserializar(QJsonObject &json)
{
    //Na lógica, não vai receber um novo usuário serializado, mas fica para efeito de padronização
    EUsuarioAdicionado ua;
    ua._id = json[EBase::Campos::ID].toInt();
    EUsuario u = UsuarioController::buscaUsuarioPeloEmail(json[Campos::NovoUsuario].toString());
    ua._novousuario = u;
    return ua;
}

QJsonObject EUsuarioAdicionado::Serializar(EUsuarioAdicionado ua)
{
    QJsonObject json;
    json[EBase::Campos::ID] = ua._id;
    json[Campos::NovoUsuario] = ua._novousuario.email();
    return json;
}
