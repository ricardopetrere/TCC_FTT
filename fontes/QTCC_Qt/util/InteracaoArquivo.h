#ifndef INTERACAOARQUIVO_H
#define INTERACAOARQUIVO_H

#include <QByteArray>
#include <QString>
#include <QFile>
#include "util/logger.h"

class InteracaoArquivo
{
public:
    static QByteArray lerArquivo(QString nome_arquivo)
    {
        QFile arquivo(nome_arquivo);
        if(!arquivo.open(QIODevice::ReadOnly))
        {
            Logger::debug("Arquivo \"" + nome_arquivo + "\" não encontrado");
            return QByteArray();
        }
        else
        {
            return arquivo.readAll();
        }
    }
    static void gravarArquivo(QString nome_arquivo, QByteArray dados)
    {
        QFile arquivo(nome_arquivo);
        if(!arquivo.open(QIODevice::WriteOnly))
        {
            Logger::debug("Impossível salvar arquivo \"" + nome_arquivo + "\".");
        }
        else
        {
            arquivo.write(dados);
        }
    }
};

#endif // INTERACAOARQUIVO_H
