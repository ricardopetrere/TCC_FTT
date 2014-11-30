#ifndef EUSUARIOADICIONADO_H
#define EUSUARIOADICIONADO_H

#include "eusuario.h"

class EUsuarioAdicionado: public EBase
{
public:
    EUsuarioAdicionado();
    int IdContato() const;
    void setIdContato(const int &id_contato);
    EUsuario NovoUsuario() const;
    void setNovoUsuario(const EUsuario &novousuario);
    static EUsuarioAdicionado Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EUsuarioAdicionado ua);
    class Campos
    {
        public:
            static const QString NovoUsuario;
    };
protected:
    EUsuario _novousuario;
};

#endif // EUSUARIOADICIONADO_H
