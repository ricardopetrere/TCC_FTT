#ifndef ECONVERSA_H
#define ECONVERSA_H

#include <QList>
#include "emensagem.h"
#include "econtato.h"
#include <QFile>
#include "ngc/logger.h"
#include <QJsonObject>
#include <QJsonDocument>
#include <QJsonArray>
#include "ui/mainwindow.h"
#include "util/InteracaoArquivo.h"

class EConversa
{
public:
    EConversa();
    EContato contato();
    QList<EMensagem> mensagens();
    void setContato(EContato &contato);
    void setMensagens(QList<EMensagem> &mensagens);
    static QList<EConversa> lerConversas()
    {
        QList<EConversa> retorno;
//        QFile arquivo_conversas(MainWindow::_usuario_logado.Id() << "/conversas.json");
//        if(!arquivo_conversas.open(QIODevice::ReadOnly))
//        {
//            Logger::debug("Arquivo \"conversas.json\" não encontrado");
//            return retorno;
//        }
//        else
//        {
//            QJsonDocument load(QJsonDocument::fromJson(arquivo_conversas.readAll()));
        int id_usuario = MainWindow::_usuario_logado.Id();
        QJsonDocument load(QJsonDocument::fromJson(InteracaoArquivo::lerArquivo(id_usuario + "/conversas.json")));
        QJsonObject conteudo_json = load.object();
        QJsonArray json_conversas(conteudo_json["Conversas"].toArray());
        for (int conversaIndex = 0; conversaIndex < json_conversas.size(); ++conversaIndex)
        {
            QJsonObject conversaObject = json_conversas[conversaIndex].toObject();
            retorno.append(EConversa::Deserializar(conversaObject));
        }
        return retorno;
//        }
    }
    static void salvarConversas(QList<EConversa> conversas)
    {
//        QFile arquivo_conversas("conversas.json");
//        if(!arquivo_conversas.open(QIODevice::WriteOnly))
//        {
//            Logger::debug("Impossível salvar arquivo \"conversas.json\"");
//        }
//        else
//        {
        QJsonArray json_conversas;
        foreach (EConversa conversa, conversas)
            json_conversas.append(EConversa::Serializar(conversa));
        QJsonObject json_arquivo;
        json_arquivo["Conversas"] = json_conversas;
        QJsonDocument save(json_arquivo);
        int id_usuario = MainWindow::_usuario_logado.Id();
        InteracaoArquivo::gravarArquivo(QString(id_usuario) + "/conversas.json",save.toJson());
//            arquivo_conversas.write(save.toJson());
//        }
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
