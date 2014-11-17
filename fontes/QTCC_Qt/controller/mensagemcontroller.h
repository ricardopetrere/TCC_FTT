#ifndef MENSAGEMCONTROLLER_H
#define MENSAGEMCONTROLLER_H

#include <QList>
#include <controller/basecontroller.h>
#include <vo/emensagem.h>


class MensagemController
{
public:
    static bool enviaEMensagemParaServidor(EMensagem m)
    {

    }

    static QList<EMensagem> retornaMensagens(int &cont_id)
    {

    }
};

#endif // MENSAGEMCONTROLLER_H
