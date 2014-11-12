#include "emensagem.h"
#include <QJsonObject>

const QString EMensagem::Campos::Contato_De = "Contato_De";
const QString EMensagem::Campos::Contato_Para = "Contato_Para";
const QString EMensagem::Campos::Data = "Data";
const QString EMensagem::Campos::Status_Envio = "Status_Envio";
const QString EMensagem::Campos::Tipo_Mensagem = "Tipo_Mensagem";
const QString EMensagem::Campos::Dados = "Dados";
const QString EMensagem::Campos::Contato_De_Deletou = "Contato_De_Deletou";
const QString EMensagem::Campos::Contato_Para_Deletou = "Contato_Para_Deletou";

EMensagem::EMensagem() : EBase()
{
    _contato_de = EContato();
    _contato_para = EContato();
    _data = QDate();
    _status_envio = Constantes::EntregaPendente;
    _tipo_mensagem = Constantes::Texto;
    _dados = NULL;
    _contato_de_deletou = false;
    _contato_para_deletou = false;
}

QJsonObject EMensagem::Serializar(EMensagem &m)
{
    QJsonObject json;
    json[EBase::Campos::ID] = m._id;
    json[EMensagem::Campos::Contato_De] = m._contato_de.Id();
    json[EMensagem::Campos::Contato_Para] = m._contato_para.Id();
//    json[EMensagem::Campos::Contato_De] = EContato::Serializar(m._contato_de);
//    json[EMensagem::Campos::Contato_Para] = EContato::Serializar(m._contato_para);
    json[EMensagem::Campos::Data] = m._data.toString(Qt::TextDate);
    json[EMensagem::Campos::Status_Envio] = m._status_envio;
    json[EMensagem::Campos::Tipo_Mensagem] = m._tipo_mensagem;
    json[EMensagem::Campos::Dados] = QString(m._dados);
    json[EMensagem::Campos::Contato_De_Deletou] = m._contato_de_deletou;
    json[EMensagem::Campos::Contato_Para_Deletou] = m._contato_para_deletou;
    return json;
}

EMensagem EMensagem::Deserializar(QJsonObject &json)
{
    EMensagem m;
    m._id = json[EBase::Campos::ID].toInt();
    m._contato_de = EContato::busca(json[EMensagem::Campos::Contato_De].toInt());
    m._contato_para = EContato::busca(json[EMensagem::Campos::Contato_Para].toInt());
//    m._contato_de = EContato::busca(json[EMensagem::Campos::Contato_De].toObject());
//    m._contato_para = EContato::Deserializar(json[EMensagem::Campos::Contato_Para].toObject());
    m._data = QDate::fromString(json[EMensagem::Campos::Data].toString());
    m._status_envio = Constantes::EStatusEnvioEnum(json[EMensagem::Campos::Status_Envio].toInt());//ou toDouble()
    m._tipo_mensagem = Constantes::ETipoMensagemEnum(json[EMensagem::Campos::Tipo_Mensagem].toInt());
    m._dados = json[EMensagem::Campos::Dados].toString().toLatin1();
    m._contato_de_deletou = json[EMensagem::Campos::Contato_De_Deletou].toBool();
    m._contato_para_deletou = json[EMensagem::Campos::Contato_Para_Deletou].toBool();
    return m;
}
