#ifndef ECONVERSA_H
#define ECONVERSA_H

#include <QList>
#include <QFile>
#include <QJsonObject>
#include <QJsonDocument>
#include <QJsonArray>
#include "emensagem.h"
#include "eusuario.h"

//#include "econtato.h"
//#include "util/logger.h"
//#include "ui/mainwindow.h"
//#include "util/InteracaoArquivo.h"

class EConversa
{
public:
    EConversa();

    static QList<EConversa> _usuario_conversas;

    void setContato(EContato &contato);
    EContato contato();
    void setMensagens(QList<EMensagem> &mensagens);
    QList<EMensagem> mensagens();

    static QList<EConversa> lerConversas()
    {
        int cont_id = EUsuario::_usuario_logado.Id();
        QList<EConversa> retorno;
        QJsonDocument load(QJsonDocument::fromJson(InteracaoArquivo::lerArquivo(cont_id + "/conversas.json")));
        QJsonObject conteudo_json = load.object();
        QJsonArray json_conversas(conteudo_json["Conversas"].toArray());
        for (int conversaIndex = 0; conversaIndex < json_conversas.size(); ++conversaIndex)
        {
            QJsonObject conversaObject = json_conversas[conversaIndex].toObject();
            retorno.append(EConversa::Deserializar(conversaObject));
        }
        return retorno;
    }
    static void salvarConversas(QList<EConversa> conversas)
    {
        int cont_id = EUsuario::_usuario_logado.Id();
        QJsonArray json_conversas;
        foreach (EConversa conversa, conversas)
            json_conversas.append(EConversa::Serializar(conversa));
        QJsonObject json_arquivo;
        json_arquivo["Conversas"] = json_conversas;
        QJsonDocument save(json_arquivo);
        InteracaoArquivo::gravarArquivo(cont_id + "/conversas.json",save.toJson());
    }
    static QJsonObject Serializar(EConversa &c);
    static EConversa Deserializar(QJsonObject &json);

    class Campos
    {
    public:
        static const QString Contato;
        static const QString Mensagens;
    };

protected:
    EContato _contato;
    QList<EMensagem> _mensagens;
};

#endif // ECONVERSA_H
