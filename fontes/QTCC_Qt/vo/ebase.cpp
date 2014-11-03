#include "ebase.h"

const QString EBase::Campos::ID="Id";

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

QJsonObject EBase::Serializar(const EBase e)
{
}

EBase EBase::Deserializar(const QJsonObject json)
{
}
