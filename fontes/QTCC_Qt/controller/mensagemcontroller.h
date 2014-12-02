#ifndef MENSAGEMCONTROLLER_H
#define MENSAGEMCONTROLLER_H

#include <QList>
#include <controller/basecontroller.h>
#include <vo/emensagem.h>
#include <vo/constantes.h>
#include <controller/usuariocontroller.h>

class MensagemController
{
public:
    static bool EnviarNovaMensagem(EMensagem m)
    {
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("EnviarNovaMensagem|"+QString(QJsonDocument(EMensagem::Serializar(m)).toJson()));
        return !(recebido.isEmpty() && recebido==NULL);
    }
    static QList<EMensagem> ReceberNovasMensagens()
    {
        return ReceberNovasMensagens(UsuarioController::_usuario_logado.Id());
    }

    static QList<EMensagem> ReceberNovasMensagens(int cont_id)
    {
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("ReceberNovasMensagens|"+QString::number(cont_id));
        QList<EMensagem> retorno;
        if(recebido!=NULL)
        {
            QJsonArray array = QJsonDocument::fromJson(recebido.toLatin1()).array();
            for (int objetoIndex = 0;objetoIndex<array.size();objetoIndex++)
            {
                QJsonObject objeto = array[objetoIndex].toObject();
                retorno.append(EMensagem::Deserializar(objeto));
            }
        }
        return retorno;
    }
    static Constantes::EStatusEnvioEnum StatusMensagem(EMensagem m)
    {
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("StatusMensagem|"+QString(QJsonDocument(EMensagem::Serializar(m)).toJson()));
        if(!(recebido.isEmpty()||recebido.isNull()))
        {
            return Constantes::EStatusEnvioEnum(recebido.toInt());
        }
        return Constantes::EntregaPendente;
    }
};

#endif // MENSAGEMCONTROLLER_H
