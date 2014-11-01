#ifndef EBASE_H
#define EBASE_H

#include <QString>
#include <QJsonObject>

class EBase
{
public:
    EBase();
    int &Id();
    void setId(int &id);

    static QJsonObject Serializar(EBase e);
    static EBase Deserializar(QJsonObject json);
    class Campos
    {
    public:
        static const QString ID;
    };

protected:
    int _id;
};
const QString EBase::Campos::ID="Id";

#endif // EBASE_H
