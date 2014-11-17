#ifndef DIALOGLOGIN_H
#define DIALOGLOGIN_H

#include <QDialog>

#include <controller/usuariocontroller.h>

namespace Ui {
class DialogLogin;
}

class DialogLogin : public QDialog
{
    Q_OBJECT

public:
    explicit DialogLogin(QWidget *parent = 0);
    ~DialogLogin();

    static void validaLogin(bool estado_para_checar,QWidget *parent)
    {
        if(estado_para_checar!=UsuarioController::estaLogado())
        {
            DialogLogin *l = new DialogLogin(parent);
            l->exec();
        }
    }
private slots:
    void on_btnLogin_clicked();

    void on_btnCadastre_se_clicked();

private:
    Ui::DialogLogin *ui;
};

#endif // DIALOGLOGIN_H
