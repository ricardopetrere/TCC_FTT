#ifndef EBASE_H
#define EBASE_H

#include <QString>
#include <QJsonDocument>
#include <QJsonObject>
#include <QJsonArray>

class EBase
{
public:
    EBase();
    const int &Id();
    void setId(const int &id);

    static QJsonObject Serializar(const EBase &e);
    static EBase Deserializar(const QJsonObject &json);
    class Campos
    {
    public:
        static const QString ID;
    };

protected:
    int _id;
};

#endif // EBASE_H
