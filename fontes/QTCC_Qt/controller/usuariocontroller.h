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
        return !(_recebido = comm.enviaPacote("NovoCadastro|" + QString(QJsonDocument(EUsuario::Serializar(u)).toJson()))).isEmpty();
    }
    static QString &recebido()
    {
        return _recebido;
    }

private:
    static QString _recebido;
};

#endif // USUARIOCONTROLLER_H
