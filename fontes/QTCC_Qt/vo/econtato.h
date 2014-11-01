#ifndef ECONTATO_H
#define ECONTATO_H

#include <vo/ebase.h>
#include <QImage>

class EContato : public EBase
{
public:
    EContato();
    void setNome( QString &nome);
    QString &Nome();
    void setFoto(QImage &foto);
    QImage &Foto();
    void setInativo(bool &inativo);
    bool &Inativo();

    static EContato Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EContato e);
    class Campos
    {
        public:
            static const QString IDContato;
            static const QString Nome;
            static const QString Foto;
            static const QString Inativo;
    };
protected:
    QString _nome;
    QImage _foto;
    bool _inativo;
};
const QString EContato::Campos::IDContato = "IDContato";
const QString EContato::Campos::Nome = "Nome";
const QString EContato::Campos::Foto = "Foto";
const QString EContato::Campos::Inativo = "Inativo";
#endif // ECONTATO_H
