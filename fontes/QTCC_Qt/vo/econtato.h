#ifndef ECONTATO_H
#define ECONTATO_H

#include <vo/ebase.h>
#include <QImage>

class EContato : public EBase
{
public:
    EContato();
    void setNome(const QString &nome);
    const QString &Nome();
    void setFoto(const QImage &foto);
    const QImage &Foto();
    void setInativo(const bool &inativo);
    const bool &Inativo();

    static EContato busca(const int &id);

    static EContato Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EContato e);
    class Campos
    {
        public:
            //static const QString IDContato;
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
