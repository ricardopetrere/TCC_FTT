#ifndef USER_H
#define USER_H

#include <QJsonObject>
#include <QList>

#include "message.h"

class User
{
public:
    User();

    const QString &nome() const;
    void setnome(const QString &nome);
    const int &idade() const;
    void setidade(const int &idade);

    const QList<Message> &messages() const;
    void setmessages(const QList<Message> &messages);

    void read(const QJsonObject &json);
    void write(QJsonObject &json) const;
private:
    QString mnome;
    int midade;

    QList<Message> mmessages;
};

#endif // USER_H
