#ifndef EUSUARIO_H
#define EUSUARIO_H
//#pragma once
#include <QList>
#include <vo/econtato.h>

class EUsuario : public EContato
{
public:
    EUsuario();
    EUsuario(EContato c);
    using EContato::setId;
    using EContato::Id;
    using EContato::setNome;
    using EContato::Nome;
    using EContato::Foto;

    static EUsuario _usuario_logado;

    static bool estaLogado()
    {
        return _usuario_logado.Id()!=-1;
    }

    static QList<EContato> _usuario_contatos;

    static void lerContatos()
    {
        _usuario_contatos = EContato::lerContatos(_usuario_logado.Id());
    }

    QString texto_status() const;
    void setTexto_status(const QString &texto_status);

    QList<EContato> contatos() const;
    void setContatos(const QList<EContato> &contatos);

    QString email() const;
    void setEmail(const QString &email);

    QString senha() const;
    void setSenha(const QString &senha);

    bool cadastraNovo();

    static EUsuario Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EUsuario u);
    class Campos
    {
        public:
            static const QString Texto_Status;
            static const QString Contatos;
            static const QString Email;
            static const QString Senha;
    };
protected:
    QString _texto_status;
    QList<EContato> _contatos;
    QString _email;
    QString _senha;
};

#endif // EUSUARIO_H
