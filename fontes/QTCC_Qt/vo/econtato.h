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
    void setImage(QImage &imagem);
    QImage &Imagem();
    void setInativo(bool &inativo);
    bool &Inativo();

    static EContato Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EContato e);
protected:
    QString _nome;
    QImage _imagem;
    bool _inativo;
};

#endif // ECONTATO_H
