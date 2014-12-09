#ifndef CONSTANTES_H
#define CONSTANTES_H

class Constantes
{
public:
    Constantes();
    //Enumerador com os diferentes status de envio de uma mensagem
    enum EStatusEnvioEnum{
        EntregaPendente=1,
        EnviadoAoServidor=2,
        DestinatarioRecebeu=3
    };
    //Enumerador com os diferentes tipos de mensagem
    enum ETipoMensagemEnum{
        GravacaoVoz=1,
        Texto=2,
        Imagem=3,
        Audio=4,
        Video=5
    };
    //Enumerador com os diferentes tipos de pacote de dados enviados ao servidor
    enum ETiposPacotesDadosEnum{
        RequisicaoLogin = 1,
        ReceberNovasMensagens=2,
        EnviarNovaMensagem=3,
        StatusContato=4,
        StatusMensagem=5,
        NovoCadastro=6,
        EnviarNovoUsuario=7,
        EnviarNovoGrupo=8,
        BuscaUsuarioPeloEmail=9,
        BuscaUsuarioPeloID=10,
        BuscaContato=11
    };
};

#endif // CONSTANTES_H
