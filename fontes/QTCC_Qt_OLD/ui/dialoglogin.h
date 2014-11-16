#ifndef DIALOGLOGIN_H
#define DIALOGLOGIN_H

#include <QDialog>
#include "vo/eusuario.h"
//#include "mainwindow.h"

namespace Ui {
class DialogLogin;
}

class DialogLogin : public QDialog
{
    Q_OBJECT

public:
    explicit DialogLogin(QWidget *parent = 0);
    ~DialogLogin();
    static bool estaLogado()
    {
        return EUsuario::_usuario_logado.Id()!=-1;
    }
    static void validaLogin(bool estado_para_checar,QWidget *parent)
    {
        if(estado_para_checar!=estaLogado())
        {
            DialogLogin *l = new DialogLogin(parent);
            l->exec();
        }
    }
    static void realizaLogout()
    {
//        MainWindow::_usuario_logado = EUsuario();
        EUsuario::_usuario_logado = EUsuario();
    }

private slots:
    void on_btnLogin_clicked();

    void on_btnCadastre_se_clicked();

private:
    Ui::DialogLogin *ui;
};

#endif // DIALOGLOGIN_H
