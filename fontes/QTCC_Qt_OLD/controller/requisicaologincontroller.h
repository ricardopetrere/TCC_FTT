#ifndef REQUISICAOLOGINCONTROLLER_H
#define REQUISICAOLOGINCONTROLLER_H

#include <QJsonDocument>
//#include "vo/eusuario.h"
#include "vo/erequisicaologin.h"
#include "util/comunicacaorede.h"

class RequisicaoLoginController
{
public:
    static EUsuario requisicaoLogin(ERequisicaoLogin login)
    {
        EUsuario retorno;
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("RequisicaoLogin|" + QString(QJsonDocument(ERequisicaoLogin::Serializar(login)).toJson()));
        if(recebido!=NULL)
        {
            QJsonObject json = QJsonDocument::fromJson(recebido.toLatin1()).object();
            return retorno = EUsuario::Deserializar(json);
        }
        return retorno = EUsuario();
    }
};

#endif // REQUISICAOLOGINCONTROLLER_H
