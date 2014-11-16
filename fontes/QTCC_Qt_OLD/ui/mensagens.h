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
    void on_listMensagens_customContextMenuRequested(const QPoint &pos);

    void on_btnEnviar_clicked();

private:
    Ui::Mensagens *ui;
};

#endif // MENSAGENS_H
