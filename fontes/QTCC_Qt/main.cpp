#include "ui/mainwindow.h"
#include "ui/conversas.h"
#include "ui/contatos.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    //MainWindow w;
    //Conversas w;
    Contatos w;
    w.show();

    return a.exec();
}
