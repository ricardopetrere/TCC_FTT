#ifndef USUARIOCONTROLLER_H
#define USUARIOCONTROLLER_H

#include <QJsonDocument>
//#include <QString>
#include <vo/eusuario.h>
#include <util/comunicacaorede.h>

class UsuarioController
{
public:
    static bool cadastraNovo(EUsuario u)
    {
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("NovoCadastro|" + QString(QJsonDocument(EUsuario::Serializar(u)).toJson()));
        return (!recebido.isEmpty() && recebido==NULL);
    }
};

#endif // USUARIOCONTROLLER_H
