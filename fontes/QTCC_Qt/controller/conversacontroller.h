#ifndef CONVERSACONTROLLER_H
#define CONVERSACONTROLLER_H

#include "usuariocontroller.h"

#include <controller/basecontroller.h>
#include <util/interacaoarquivo.h>
#include <vo/econversa.h>

class ConversaController
{
public:
    static QList<EConversa> _usuario_conversas;

    static QList<EConversa> lerConversasUsuarioLogado()
    {
        int cont_id = UsuarioController::_usuario_logado.Id();
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
    static void salvarConversasUsuarioLogado(QList<EConversa> conversas)
    {
        int cont_id = UsuarioController::_usuario_logado.Id();
        QJsonArray json_conversas;
        foreach (EConversa conversa, conversas)
            json_conversas.append(EConversa::Serializar(conversa));
        QJsonObject json_arquivo;
        json_arquivo["Conversas"] = json_conversas;
        QJsonDocument save(json_arquivo);
        InteracaoArquivo::gravarArquivo(cont_id + "/conversas.json",save.toJson());
    }
};

#endif // CONVERSACONTROLLER_H
