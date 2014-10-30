#ifndef EMENSAGEM_H
#define EMENSAGEM_H

#include <vo/ebase.h>
#include <vo/econtato.h>
#include <QDate>

class EMensagem : public EBase
{
public:
    EMensagem();
    enum EStatusEnvioEnum{

    };
    enum ETipoMensagemEnum{

    };
    bool enviaEMensagemParaServidor();

protected:
    EContato _contato_de;
    EContato _contato_para;
    QDate _data;
    EStatusEnvioEnum _status_envio;
    ETipoMensagemEnum _tipo_mensagem;
    QByteArray _dados;
    bool _contato_de_deletou;
    bool _contato_para_deletou;
};

#endif // EMENSAGEM_H
