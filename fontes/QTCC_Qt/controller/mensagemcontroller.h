#ifndef MENSAGEMCONTROLLER_H
#define MENSAGEMCONTROLLER_H

#include <QList>
#include <controller/basecontroller.h>
#include <vo/emensagem.h>


class MensagemController
{
public:
    static bool EnviarNovaMensagem(EMensagem m)
    {

    }

    static QList<EMensagem> ReceberNovasMensagens(int &cont_id)
    {

    }
};

#endif // MENSAGEMCONTROLLER_H
