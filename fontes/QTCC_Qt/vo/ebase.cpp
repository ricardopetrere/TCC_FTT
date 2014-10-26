#include "ebase.h"

EBase::EBase()
{
    _id = -1;
}

int &EBase::Id()
{
    return _id;
}

void EBase::setId(int &id)
{
    _id = id;
}

QJsonObject EBase::Serializar(EBase e)
{

}

EBase EBase::Deserializar(QJsonObject json)
{

}
