#ifndef ECONTATO_H
#define ECONTATO_H
//#pragma once
#include <QImage>
#include <vo/ebase.h>

class EContato : public EBase
{
public:
    EContato();
    using EBase::setId;
    using EBase::Id;
    void setNome(const QString &nome);
    const QString &Nome();
    void setFoto(const QImage &foto);
    const QImage &Foto();
    void setInativo(const bool &inativo);
    const bool &Inativo();

    static QJsonObject Serializar(EContato c);
    static EContato Deserializar(QJsonObject &json);
    class Campos
    {
        public:
            static const QString Nome;
            static const QString Foto;
            static const QString Inativo;
    };
protected:
    QString _nome;
    QImage _foto;
    bool _inativo;
};
#endif // ECONTATO_H
