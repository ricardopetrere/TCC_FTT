#ifndef USUARIOCONTROLLER_H
#define USUARIOCONTROLLER_H

#include <vo/eusuario.h>
#include <controller/contatocontroller.h>
#include <vo/eusuarioadicionado.h>

class UsuarioController
{
public:
    static void lerContatosUsuarioLogado()
    {
//        ContatoController::_usuario_contatos = ContatoController::lerContatosUsuario_JSON(UsuarioController::_usuario_logado.Id());
        ContatoController::_usuario_contatos = UsuarioController::_usuario_logado.contatos();
    }
    static void salvarContatosUsuarioLogado()
    {
        ContatoController::salvarContatos(ContatoController::_usuario_contatos,UsuarioController::_usuario_logado.Id());
    }
    static EUsuario _usuario_logado;
    static EUsuario buscaUsuarioPeloEmail(QString usu_email)
    {
        EUsuario retorno;
        //Primeiro checa na lista interna, pra evitar tráfego na rede
        foreach (EContato contato, ContatoController::_usuario_contatos)
        {
//            EUsuario* contato_as_usuario = dynamic_cast<EUsuario*>(&contato);
//            if(contato_as_usuario.Id()>0)
//                if(contato_as_usuario.email()==usu_email)
//                    return contato_as_usuario;
        }
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("BuscaUsuarioPeloEmail|"+usu_email);
        if(recebido!=NULL)
        {
            QJsonObject json = QJsonDocument::fromJson(recebido.toLatin1()).object();
            return retorno = EUsuario::Deserializar(json);
        }
        return retorno = EUsuario();
    }
    static EUsuario buscaUsuarioPeloID(int cont_id)
    {
        EUsuario retorno;
        //Primeiro checa na lista interna, pra evitar tráfego na rede
        foreach (EContato contato, ContatoController::_usuario_contatos) {
                if(contato.Id()==cont_id)
                    return contato;
        }
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("BuscaUsuarioPeloID|"+cont_id);
        if(recebido!=NULL)
        {
            QJsonObject json = QJsonDocument::fromJson(recebido.toLatin1()).object();
            return retorno = EUsuario::Deserializar(json);
        }
        return retorno = EUsuario();
    }
    static bool cadastraNovo(EUsuario u)
    {
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("NovoCadastro|" + QString(QJsonDocument(EUsuario::Serializar(u)).toJson()));
        return (!recebido.isEmpty() && recebido==NULL);
    }
    static QString EnviarNovoUsuario(EUsuario u)
    {
        EUsuarioAdicionado ua;
        ua.setId(UsuarioController::_usuario_logado.Id());
        ua.setNovoUsuario(u);
        ComunicacaoRede comm;
        QString recebido = comm.enviaPacote("EnviarNovoUsuario|"+QString(QJsonDocument(EUsuarioAdicionado::Serializar(ua)).toJson()));
        return recebido;
    }

    static bool estaLogado()
    {
        return UsuarioController::_usuario_logado.Id()!=-1;
    }

    static void realizaLogout()
    {
        UsuarioController::_usuario_logado = EUsuario();
    }
};

#endif // USUARIOCONTROLLER_H
