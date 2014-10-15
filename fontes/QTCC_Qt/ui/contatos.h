#ifndef CONTATOS_H
#define CONTATOS_H

#include <QMainWindow>

namespace Ui {
class Contatos;
}

class Contatos : public QMainWindow
{
    Q_OBJECT

public:
    explicit Contatos(QWidget *parent = 0);
    ~Contatos();

private:
    Ui::Contatos *ui;
};

#endif // CONTATOS_H
