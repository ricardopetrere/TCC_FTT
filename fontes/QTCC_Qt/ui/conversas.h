#ifndef CONVERSAS_H
#define CONVERSAS_H

#include <QMainWindow>

namespace Ui {
class Conversas;
}

class Conversas : public QMainWindow
{
    Q_OBJECT

public:
    explicit Conversas(QWidget *parent = 0);
    ~Conversas();

private:
    Ui::Conversas *ui;
};

#endif // CONVERSAS_H
