#ifndef EMENSAGEM_H
#define EMENSAGEM_H

#include <QDate>
#include <QJsonObject>
#include <vo/constantes.h>
//#include <vo/ebase.h>
#include <vo/econtato.h>

class EMensagem : public EBase
{
public:
    EMensagem();
    bool enviaEMensagemParaServidor();

    void setContato_De(EContato &contato_de);
    EContato Contato_De();
    void setContato_Para(EContato &contato_para);
    EContato Contato_Para();
    void setData(QDate &data);
    QDate Data();
    void setStatus_Envio(Constantes::EStatusEnvioEnum &status_envio);
    Constantes::EStatusEnvioEnum Status_Envio();
    void setTipo_Mensagem(Constantes::ETipoMensagemEnum &tipo_mensagem);
    Constantes::ETipoMensagemEnum Tipo_Mensagem();
    void setDados(QByteArray dados);
    QByteArray Dados();
    void setContato_De_Deletou(bool &contato_de_deletou);
    bool Contato_De_Deletou();
    void setContato_Para_Deletou(bool &contato_para_deletou);
    bool Contato_Para_Deletou();

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
