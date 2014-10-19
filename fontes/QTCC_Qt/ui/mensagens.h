#ifndef MENSAGENS_H
#define MENSAGENS_H

#include <QMainWindow>

namespace Ui {
class Mensagens;
}

class Mensagens : public QMainWindow
{
    Q_OBJECT

public:
    explicit Mensagens(QWidget *parent = 0);
    ~Mensagens();

private slots:
    void on_listWidget_customContextMenuRequested(const QPoint &pos);

private:
    Ui::Mensagens *ui;
};

#endif // MENSAGENS_H
