#include <QCoreApplication>
#include <serversocket.h>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    ServerSocket myserver;

    return a.exec();
}
