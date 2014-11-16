#ifndef EREQUISICAOLOGIN_H
#define EREQUISICAOLOGIN_H

#include <QString>
#include <QJsonObject>
#include "eusuario.h"

class ERequisicaoLogin
{
public:
    ERequisicaoLogin();
    EUsuario requisicaoLogin();

    QString login() const;
    void setLogin(const QString &login);

    QString senha() const;
    void setSenha(const QString &senha);

    static ERequisicaoLogin Deserializar(QJsonObject &json);
    static QJsonObject Serializar(ERequisicaoLogin l);
    class Campos
    {
    public:
        static const QString Login;
        static const QString Senha;
    };
protected:
    QString _login;
    QString _senha;
};

#endif // EREQUISICAOLOGIN_H
