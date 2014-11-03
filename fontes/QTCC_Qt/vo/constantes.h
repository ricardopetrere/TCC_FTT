#ifndef CONSTANTES_H
#define CONSTANTES_H

class Constantes
{
public:
    Constantes();
    enum EStatusEnvioEnum{
        EntregaPendente=1,
        EnviadoAoServidor=2,
        DestinatarioRecebeu=3
    };
    enum ETipoMensagemEnum{
        GravacaoVoz=1,
        Texto=2,
        Imagem=3,
        Audio=4,
        Video=5
    };
    enum TiposPacotesDadosEnum{
        RequisicaoLogin = 1,
        ReceberNovasMensagens=2,
        EnviarNovaMensagem=3,
        StatusContato=4,
        StatusMensagem=5,
        NovoCadastro=6,
        EnviarNovoUsuario=7,
        EnviarNovoGrupo=8
    };

};

#endif // CONSTANTES_H
