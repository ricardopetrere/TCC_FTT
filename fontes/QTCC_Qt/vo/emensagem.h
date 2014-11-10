#ifndef EMENSAGEM_H
#define EMENSAGEM_H

#include <vo/ebase.h>
#include <vo/econtato.h>
#include <vo/constantes.h>
#include <QDate>
#include <QJsonObject>

class EMensagem : public EBase
{
public:
    EMensagem();
    bool enviaEMensagemParaServidor();
    static QJsonObject Serializar(EMensagem &m);
    static EMensagem Deserializar(QJsonObject &json);
    class Campos
    {
    public:
        static const QString Contato_De;
        static const QString Contato_Para;
        static const QString Data;
        static const QString Status_Envio;
        static const QString Tipo_Mensagem;
        static const QString Dados;
        static const QString Contato_De_Deletou;
        static const QString Contato_Para_Deletou;
    };
protected:
    EContato _contato_de;
    EContato _contato_para;
    QDate _data;
    Constantes::EStatusEnvioEnum _status_envio;
    Constantes::ETipoMensagemEnum _tipo_mensagem;
    QByteArray _dados;
    bool _contato_de_deletou;
    bool _contato_para_deletou;
};

#endif // EMENSAGEM_H
