#ifndef ECONTATO_H
#define ECONTATO_H

#include <vo/ebase.h>
#include <QImage>
#include <util/InteracaoArquivo.h>
#include "ui/mainwindow.h"
#include <QJsonDocument>
#include <QJsonObject>
#include <QJsonArray>

class EContato : public EBase
{
public:
    EContato();
    void setNome(const QString &nome);
    const QString &Nome();
    void setFoto(const QImage &foto);
    const QImage &Foto();
    void setInativo(const bool &inativo);
    const bool &Inativo();

    static EContato busca(const int &id);
    static QList<EContato> lerContatos()
    {
        QList<EContato> retorno;
        int id_usuario = MainWindow::_usuario_logado.Id();
        QJsonDocument load(QJsonDocument::fromJson(InteracaoArquivo::lerArquivo(id_usuario + "/contatos.json")));
        QJsonObject conteudo_json = load.object();
        QJsonArray json_contatos(conteudo_json["Contatos"].toArray());
        for (int contatoIndex = 0; contatoIndex < json_contatos.size(); ++contatoIndex)
        {
            QJsonObject contatoObject = json_contatos[contatoIndex].toObject();
            retorno.append(EContato::Deserializar(contatoObject));
        }
        return retorno;
    }
    static void salvarContatos(QList<EContato> contatos)
    {
        QJsonArray json_contatos;
        foreach (EContato contato, contatos)
            json_contatos.append(EContato::Serializar(contato));
        QJsonObject json_arquivo;
        json_arquivo["Contatos"] = json_contatos;
        QJsonDocument save(json_arquivo);
        int id_usuario = MainWindow::_usuario_logado.Id();
        InteracaoArquivo::gravarArquivo(QString(id_usuario) + "/contatos.json",save.toJson());
    }

    static EContato Deserializar(QJsonObject &json);
    static QJsonObject Serializar(EContato e);
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
