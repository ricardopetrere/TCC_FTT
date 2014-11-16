#include "econversa.h"

EConversa::EConversa()
{
    _contato = EContato();
    _mensagens = QList<EMensagem>();
}

EContato EConversa::contato()
{
    return _contato;
}

QList<EMensagem> EConversa::mensagens()
{
    return _mensagens;
}

void EConversa::setContato(EContato &contato)
{
    _contato = contato;
}

void EConversa::setMensagens(QList<EMensagem> &mensagens)
{
    _mensagens = mensagens;
}
