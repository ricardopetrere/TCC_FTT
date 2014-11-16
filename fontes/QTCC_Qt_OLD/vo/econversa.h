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
//#include "ngc/logger.h"
//#include "ui/mainwindow.h"
//#include "util/InteracaoArquivo.h"

class EConversa
{
public:
    EConversa();

    static QList<EConversa> _usuario_conversas;

//    static void lerConversas()
//    {
//        _usuario_conversas = EConversa::lerConversas();
//    }

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
    static QJsonObject Serializar(EConversa &conversa)
    {
        QJsonObject json;
        json["Contato"] = conversa.contato().Id();
        QJsonArray mensagensArray;
        foreach (EMensagem mensagem, conversa.mensagens())
            mensagensArray.append(EMensagem::Serializar(mensagem));
        json["Mensagens"] = mensagensArray;
        return json;
    }
    static EConversa Deserializar(QJsonObject &json)
    {
        EConversa conversa;
        conversa._contato = EContato::busca(json["Contato"].toInt());
        QJsonArray mensagemArray = json["Mensagens"].toArray();
        for(int mensagemIndex = 0;mensagemIndex<mensagemArray.size();mensagemIndex++)
        {
            QJsonObject mensagemObject = mensagemArray[mensagemIndex].toObject();
            conversa._mensagens.append(EMensagem::Deserializar(mensagemObject));
        }
        return conversa;
    }
private:
    QList<EMensagem> _mensagens;
    EContato _contato;
};

#endif // ECONVERSA_H
