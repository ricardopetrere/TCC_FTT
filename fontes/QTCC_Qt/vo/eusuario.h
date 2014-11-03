#ifndef EUSUARIO_H
#define EUSUARIO_H

#include <vo/econtato.h>
#include <QList>

class EUsuario : public EContato
{
public:
    EUsuario();
    EUsuario(EContato c);
    using EContato::setId;
    using EContato::Id;
    using EContato::setNome;
    using EContato::Nome;

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
            //static const QString IDUsuario;
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
private:
    EUsuario(EUsuario* usuario);
};

#endif // EUSUARIO_H
