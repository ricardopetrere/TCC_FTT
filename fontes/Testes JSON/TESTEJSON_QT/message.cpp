#include "message.h"

Message::Message()
{
}

QString Message::texto() const
{
    return mtexto;
}

void Message::settexto(const QString &texto)
{
    mtexto = texto;
}

void Message::read(const QJsonObject &json)
{
    mtexto = json["Texto"].toString();
}

void Message::write(QJsonObject &json) const
{
    json["Texto"] = mtexto;
}
