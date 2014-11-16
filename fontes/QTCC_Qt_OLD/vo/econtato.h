#ifndef ECONTATO_H
#define ECONTATO_H
//#pragma once
#include <QImage>
#include <QJsonDocument>
#include <QJsonObject>
#include <QJsonArray>
#include <vo/ebase.h>
#include <util/InteracaoArquivo.h>

class EContato : public EBase
{
public:
    EContato();
    using EBase::setId;
    using EBase::Id;

    void setNome(const QString &nome);
    const QString &Nome();
    void setFoto(const QImage &foto);
    const QImage &Foto();
    void setInativo(const bool &inativo);
    const bool &Inativo();

    static EContato busca(const int &id);
    static QList<EContato> lerContatos(const int &cont_id)
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

    static EContato Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EContato c);
    class Campos
    {
        public:
            static const QString Nome;
            static const QString Foto;
            static const QString Inativo;
    };
protected:
    QString _nome;
    QImage _foto;
    bool _inativo;
};
#endif // ECONTATO_H
