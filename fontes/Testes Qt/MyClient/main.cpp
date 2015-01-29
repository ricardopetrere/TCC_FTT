#include <QCoreApplication>
#include <clientsocket.h>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    ClientSocket cliente;
    cliente.Teste();
    return a.exec();
}
