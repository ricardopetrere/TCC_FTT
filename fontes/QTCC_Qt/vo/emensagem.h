#ifndef EMENSAGEM_H
#define EMENSAGEM_H

#include <vo/ebase.h>
#include <vo/econtato.h>
#include <QDate>
#include <vo/constantes.h>

class EMensagem : public EBase
{
public:
    EMensagem();
    bool enviaEMensagemParaServidor();

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
