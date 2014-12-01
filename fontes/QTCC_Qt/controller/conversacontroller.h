#ifndef CONVERSACONTROLLER_H
#define CONVERSACONTROLLER_H

#include "usuariocontroller.h"

#include <controller/basecontroller.h>
#include <util/interacaoarquivo.h>
#include <vo/econversa.h>

class ConversaController
{
public:
    static QList<EConversa>* _usuario_conversas;

    static QList<EConversa> lerConversasUsuarioLogado()
    {
        int cont_id = UsuarioController::_usuario_logado.Id();
        QList<EConversa> retorno;
        QJsonDocument load(QJsonDocument::fromJson(InteracaoArquivo::lerArquivo(QString::number(cont_id) + "_conversas.json")));
        if(load.isEmpty())
        {
            salvarConversasUsuarioLogado();
        }
        QJsonObject conteudo_json = load.object();
        QJsonArray json_conversas(conteudo_json["Conversas"].toArray());
        for (int conversaIndex = 0; conversaIndex < json_conversas.size(); ++conversaIndex)
        {
            QJsonObject conversaObject = json_conversas[conversaIndex].toObject();
            retorno.append(EConversa::Deserializar(conversaObject));
        }
        return retorno;
    }
    static void salvarConversasUsuarioLogado()
    {
        salvarConversasUsuarioLogado(_usuario_conversas);
    }

    static void salvarConversasUsuarioLogado(QList<EConversa>* conversas)
    {
        int cont_id = UsuarioController::_usuario_logado.Id();
        QJsonArray json_conversas;
        foreach (EConversa conversa, *conversas)
            json_conversas.append(EConversa::Serializar(conversa));
        QJsonObject json_arquivo;
        json_arquivo["Conversas"] = json_conversas;
        QJsonDocument save(json_arquivo);
        InteracaoArquivo::gravarArquivo(QString::number(cont_id) + "_conversas.json",save.toJson());
    }
    static EConversa* defineConversaSelecionada(QString nome_contato)
    {
        EConversa retorno;
        foreach (EConversa conversa, *_usuario_conversas)
        {
            //Verifica se já existe uma conversa
            if(conversa.contato().Nome()==nome_contato)
            {
                retorno = conversa;
                break;
            }
        }
        if(retorno.mensagens()->count()==0)
        {
            EContato contato;
            //Se não achou uma conversa com o contato, seleciona o contato em si
            foreach (EContato c, ContatoController::_usuario_contatos)
            {
                if(c.Nome()==nome_contato)
                {
                    contato = c;
                    break;
                }
            }
            retorno.setContato(contato);
            _usuario_conversas->append(retorno);
        }
        EConversa* ponteiro = new EConversa();
        *ponteiro = retorno;
        return ponteiro;
    }
};

#endif // CONVERSACONTROLLER_H
