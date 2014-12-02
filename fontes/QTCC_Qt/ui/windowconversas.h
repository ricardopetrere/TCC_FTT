#ifndef WINDOWCONVERSAS_H
#define WINDOWCONVERSAS_H

#include <QMainWindow>
#include <QListWidgetItem>
#include <controller/lermensagenscontroller.h>

namespace Ui {
class WindowConversas;
}

class WindowConversas : public QMainWindow
{
    Q_OBJECT

public:
    explicit WindowConversas(QWidget *parent = 0);
    ~WindowConversas();

    void carregaDadosUsuario();
private slots:
    void on_listConversas_itemClicked(QListWidgetItem *item);

    void on_actionNova_Conversa_triggered();

    void on_actionLogout_triggered();

    void on_listConversas_customContextMenuRequested(const QPoint &pos);

    void receberNovasMensagens();
private:
    Ui::WindowConversas *ui;
    LerMensagensController *l;
};

#endif // WINDOWCONVERSAS_H
