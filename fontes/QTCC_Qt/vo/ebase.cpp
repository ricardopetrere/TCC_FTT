#include "ebase.h"

const QString EBase::Campos::ID="ID";

EBase::EBase()
{
    _id = -1;
}

const int &EBase::Id()
{
    return _id;
}

void EBase::setId(const int &id)
{
    _id = id;
}

QJsonObject EBase::Serializar(const EBase &e)
{
    QJsonObject json;
    json[Campos::ID] = e._id;
    return json;
}

EBase EBase::Deserializar(const QJsonObject &json)
{
    EBase e;
    e._id = json[Campos::ID].toInt();
    return e;
}
