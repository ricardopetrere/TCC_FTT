#include "emensagem.h"
#include <controller/contatocontroller.h>

const QString EMensagem::Campos::Contato_De = "Contato_De";
const QString EMensagem::Campos::Contato_Para = "Contato_Para";
const QString EMensagem::Campos::Data_Envio = "Data_Envio";
const QString EMensagem::Campos::Dados = "Dados";
const QString EMensagem::Campos::Tipo_Mensagem = "Tipo_Mensagem";
const QString EMensagem::Campos::Status_Envio = "Status_Envio";
//const QString EMensagem::Campos::Contato_De_Deletou = "Contato_De_Deletou";
//const QString EMensagem::Campos::Contato_Para_Deletou = "Contato_Para_Deletou";

EMensagem::EMensagem() //: EBase()
{
    _contato_de = EContato();
    _contato_para = EContato();
    _data_envio = QDateTime::currentDateTime();
    _status_envio = Constantes::EntregaPendente;
    _tipo_mensagem = Constantes::Texto;
    _dados = NULL;
//    _contato_de_deletou = false;
//    _contato_para_deletou = false;
}

void EMensagem::setContato_De(EContato &contato_de)
{
    _contato_de = contato_de;
}

EContato EMensagem::Contato_De()
{
    return _contato_de;
}

void EMensagem::setContato_Para(EContato &contato_para)
{
    _contato_para = contato_para;
}

EContato EMensagem::Contato_Para()
{
    return _contato_para;
}

void EMensagem::setData_Envio(QDateTime &data_envio)
{
    _data_envio = data_envio;
}

QDateTime EMensagem::Data_Envio()
{
    return _data_envio;
}

void EMensagem::setStatus_Envio(Constantes::EStatusEnvioEnum &status_envio)
{
    _status_envio = status_envio;
}

Constantes::EStatusEnvioEnum EMensagem::Status_Envio()
{
    return _status_envio;
}

void EMensagem::setTipo_Mensagem(Constantes::ETipoMensagemEnum &tipo_mensagem)
{
    _tipo_mensagem = tipo_mensagem;
}

Constantes::ETipoMensagemEnum EMensagem::Tipo_Mensagem()
{
    return _tipo_mensagem;
}

void EMensagem::setDados(QByteArray &dados)
{
    _dados = dados;
}

QByteArray EMensagem::Dados()
{
    return _dados;
}

//void EMensagem::setContato_De_Deletou(bool &contato_de_deletou)
//{
//    _contato_de_deletou = contato_de_deletou;
//}

//bool EMensagem::Contato_De_Deletou()
//{
//    return _contato_de_deletou;
//}

//void EMensagem::setContato_Para_Deletou(bool &contato_para_deletou)
//{
//    _contato_para_deletou = contato_para_deletou;
//}

//bool EMensagem::Contato_Para_Deletou()
//{
//    return _contato_para_deletou;
//}

QJsonObject EMensagem::Serializar(EMensagem &m)
{
    QJsonObject json;
//    json[EBase::Campos::ID] = m._id;
    json[EMensagem::Campos::Contato_De] = m._contato_de.Id();
    json[EMensagem::Campos::Contato_Para] = m._contato_para.Id();
//    json[EMensagem::Campos::Contato_De] = EContato::Serializar(m._contato_de);
//    json[EMensagem::Campos::Contato_Para] = EContato::Serializar(m._contato_para);
    json[EMensagem::Campos::Data_Envio] = m._data_envio.toString("dd/MM/yyyy hh:mm:ss");
    json[EMensagem::Campos::Status_Envio] = m._status_envio;
    json[EMensagem::Campos::Tipo_Mensagem] = m._tipo_mensagem;
    json[EMensagem::Campos::Dados] = QString(m._dados);
//    json[EMensagem::Campos::Contato_De_Deletou] = m._contato_de_deletou;
//    json[EMensagem::Campos::Contato_Para_Deletou] = m._contato_para_deletou;
    return json;
}

EMensagem EMensagem::Deserializar(QJsonObject &json)
{
    EMensagem m;
//    m._id = json[EBase::Campos::ID].toInt();
    m._contato_de = ContatoController::busca(json[EMensagem::Campos::Contato_De].toInt());
    m._contato_para = ContatoController::busca(json[EMensagem::Campos::Contato_Para].toInt());
//    m._contato_de = EContato::busca(json[EMensagem::Campos::Contato_De].toObject());
//    m._contato_para = EContato::Deserializar(json[EMensagem::Campos::Contato_Para].toObject());
    m._data_envio = QDateTime::fromString(json[EMensagem::Campos::Data_Envio].toString(),"dd/MM/yyyy hh:mm:ss");
    m._status_envio = Constantes::EStatusEnvioEnum(json[EMensagem::Campos::Status_Envio].toInt());//ou toDouble()
    m._tipo_mensagem = Constantes::ETipoMensagemEnum(json[EMensagem::Campos::Tipo_Mensagem].toInt());
    m._dados = json[EMensagem::Campos::Dados].toString().toLatin1();
//    m._contato_de_deletou = json[EMensagem::Campos::Contato_De_Deletou].toBool();
//    m._contato_para_deletou = json[EMensagem::Campos::Contato_Para_Deletou].toBool();
    return m;
}
