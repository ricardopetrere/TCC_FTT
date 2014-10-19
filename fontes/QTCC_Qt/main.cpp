#include "ui/mainwindow.h"
#include "ui/conversas.h"
#include "ui/contatos.h"
#include "ui/mensagens.h"
#include "ui/login.h"
#include "ui/cadastre_se.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    //Conversas w;
    //Contatos w;
    //Mensagens w;
    //Login w;
    //Cadastre_se w;
    w.show();

    return a.exec();
}
