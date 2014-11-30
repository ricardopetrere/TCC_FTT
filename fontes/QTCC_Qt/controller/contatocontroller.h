#ifndef CONTATOCONTROLLER_H
#define CONTATOCONTROLLER_H

#include <controller/basecontroller.h>
#include <util/interacaoarquivo.h>
#include <vo/econtato.h>
//#include <controller/usuariocontroller.h

class ContatoController
{
public:
    static QList<EContato> _usuario_contatos;
    static EContato busca(int cont_id)
    {
        EContato e;
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("BuscaContato|"+QString::number(cont_id));
        if(recebido!=NULL)
        {
            QJsonObject json = QJsonDocument::fromJson(recebido.toLatin1()).object();
            e = EContato::Deserializar(json);
        }
        return e;
    }

    static QList<EContato> lerContatosUsuario_Rede(const int &cont_id)
    {
        QList<EContato> retorno;

        return retorno;
    }

    static QList<EContato> lerContatosUsuario_JSON(const int &cont_id)
    {
        QList<EContato> retorno;
        QJsonDocument load(QJsonDocument::fromJson(InteracaoArquivo::lerArquivo("/"+QString::number(cont_id) + "_contatos.json")));
        QJsonObject conteudo_json = load.object();
        QJsonArray json_contatos(conteudo_json["Contatos"].toArray());
        for (int contatoIndex = 0; contatoIndex < json_contatos.size(); ++contatoIndex)
        {
            QJsonObject contatoObject = json_contatos[contatoIndex].toObject();
            retorno.append(EContato::Deserializar(contatoObject));
        }
        return retorno;
    }

    static void salvarContatos(QList<EContato> contatos,const int &cont_id)
    {
        QJsonArray json_contatos;
        foreach (EContato contato, contatos)
            json_contatos.append(EContato::Serializar(contato));
        QJsonObject json_arquivo;
        json_arquivo["Contatos"] = json_contatos;
        QJsonDocument save(json_arquivo);
        InteracaoArquivo::gravarArquivo("/"+QString::number(cont_id) + "_contatos.json",save.toJson());
    }
};

#endif // CONTATOCONTROLLER_H
