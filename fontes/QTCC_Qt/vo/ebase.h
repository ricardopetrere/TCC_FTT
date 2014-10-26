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
protected:
    int _id;
};

#endif // EBASE_H
