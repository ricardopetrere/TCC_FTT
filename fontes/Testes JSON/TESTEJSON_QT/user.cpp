#include "user.h"

#include <QJsonArray>

User::User()
{
}

const QString &User::nome() const
{
    return mnome;
}

void User::setnome(const QString &nome)
{
    mnome = nome;
}

const int &User::idade() const
{
    return midade;
}

void User::setidade(const int &idade)
{
    midade = idade;
}

const QList<Message> &User::messages() const
{
    return mmessages;
}

void User::setmessages(const QList<Message> &messages)
{
    mmessages = messages;
}

void User::read(const QJsonObject &json)
{
    mnome = json["Nome"].toString();
    midade = json["Idade"].toInt();

    mmessages.clear();
    QJsonArray messageArray = json["Mensagens"].toArray();
    for (int messageIndex = 0; messageIndex < messageArray.size(); ++messageIndex) {
        QJsonObject messageObject = messageArray[messageIndex].toObject();
        Message message;
        message.read(messageObject);
        mmessages.append(message);
    }
}

void User::write(QJsonObject &json) const
{
    json["Nome"] = mnome;
    json["Idade"] = midade;
    QJsonArray messageArray;
    foreach (const Message message, mmessages) {
        QJsonObject messageObject;
        message.write(messageObject);
        messageArray.append(messageObject);
    }
    json["Mensagens"] = messageArray;
}
