#ifndef USUARIOCONTROLLER_H
#define USUARIOCONTROLLER_H

#include <vo/eusuario.h>
#include <QString>
#include <util/comunicacaorede.h>
#include <QJsonDocument>

class UsuarioController
{
public:
    static bool cadastraNovo(EUsuario u)
    {
        ComunicacaoRede comm;
        _recebido = comm.enviaPacote("NovoCadastro|" + QString(QJsonDocument(EUsuario::Serializar(u)).toBinaryData()));
        return true;
    }
    static QString &recebido()
    {
        return _recebido;
    }

private:
    static QString _recebido;
};

#endif // USUARIOCONTROLLER_H