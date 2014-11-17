#ifndef WINDOWCONVERSAS_H
#define WINDOWCONVERSAS_H

#include <QMainWindow>
#include <QListWidgetItem>

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

private:
    Ui::WindowConversas *ui;
};

#endif // WINDOWCONVERSAS_H
