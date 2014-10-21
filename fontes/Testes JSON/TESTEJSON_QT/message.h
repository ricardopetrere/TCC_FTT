#ifndef MESSAGE_H
#define MESSAGE_H

#include <QJsonObject>
#include <QString>

class Message
{
public:
    Message();
    QString texto() const;
    void settexto(const QString &texto);

    void read(const QJsonObject &json);
    void write(QJsonObject &json) const;
private:
    QString mtexto;
};

#endif // MESSAGE_H
