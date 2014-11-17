#ifndef CONTATOCONTROLLER_H
#define CONTATOCONTROLLER_H

#include <controller/basecontroller.h>
#include <util/interacaoarquivo.h>
#include <vo/econtato.h>
#include "usuariocontroller.h"

class ContatoController
{
public:
    static QList<EContato> _usuario_contatos;
    static EContato busca(const int &cont_id)
    {
        EContato e;

        return e;
    }
    static void lerContatosUsuarioLogado()
    {
        ContatoController::_usuario_contatos = lerContatosUsuario(UsuarioController::_usuario_logado.Id());
    }

    static QList<EContato> lerContatosUsuario(const int &cont_id)
    {
        QList<EContato> retorno;
        QJsonDocument load(QJsonDocument::fromJson(InteracaoArquivo::lerArquivo(cont_id + "/contatos.json")));
        QJsonObject conteudo_json = load.object();
        QJsonArray json_contatos(conteudo_json["Contatos"].toArray());
        for (int contatoIndex = 0; contatoIndex < json_contatos.size(); ++contatoIndex)
        {
            QJsonObject contatoObject = json_contatos[contatoIndex].toObject();
            retorno.append(EContato::Deserializar(contatoObject));
        }
        return retorno;
    }
    static void salvarContatosUsuarioLogado()
    {
        salvarContatos(ContatoController::_usuario_contatos,UsuarioController::_usuario_logado.Id());
    }

    static void salvarContatos(QList<EContato> contatos,const int &cont_id)
    {
        QJsonArray json_contatos;
        foreach (EContato contato, contatos)
            json_contatos.append(EContato::Serializar(contato));
        QJsonObject json_arquivo;
        json_arquivo["Contatos"] = json_contatos;
        QJsonDocument save(json_arquivo);
        InteracaoArquivo::gravarArquivo(cont_id + "/contatos.json",save.toJson());
    }
};

#endif // CONTATOCONTROLLER_H
