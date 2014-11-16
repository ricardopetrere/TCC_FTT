#include <QApplication>
#include "ui/windowconversas.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    WindowConversas w;
    w.show();
    return a.exec();
}
