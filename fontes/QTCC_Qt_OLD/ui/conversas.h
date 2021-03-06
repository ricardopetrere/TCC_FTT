#ifndef CONVERSAS_H
#define CONVERSAS_H

#include <QMainWindow>
#include <QListWidgetItem>

namespace Ui {
class Conversas;
}

class Conversas : public QMainWindow
{
    Q_OBJECT

public:
    explicit Conversas(QWidget *parent = 0);
    ~Conversas();

signals:

private slots:
    void on_listConversas_itemClicked(QListWidgetItem *item);

    void on_actionNova_Conversa_triggered();

    void on_listConversas_customContextMenuRequested(const QPoint &pos);

    void on_actionLogout_triggered();

    void carregaDadosUsuario();

private:
    Ui::Conversas *ui;
};

#endif // CONVERSAS_H
