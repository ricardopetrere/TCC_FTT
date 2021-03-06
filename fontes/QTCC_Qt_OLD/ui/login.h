#ifndef LOGIN_H
#define LOGIN_H

#include <QMainWindow>
#include "ngc/logger.h"

namespace Ui {
class Login;
}

class Login : public QMainWindow
{
    Q_OBJECT

public:
    explicit Login(QWidget *parent = 0);
    ~Login();
    static bool estaLogado()
    {
        return login!=-1;
    }
    static void validaLogin(bool estado_para_checar,QWidget *parent)
    {
        if(estado_para_checar!=estaLogado())
        {
            Login *l = new Login(parent);
            l->setWindowModality(Qt::WindowModal);
            l->show();
        }
    }
    static void realizaLogout()
    {
        login = -1;
    }

private slots:
    void on_btnLogin_clicked();

    void on_btnCadastre_se_clicked();

private:
    Ui::Login *ui;
    static int login;
protected:
    void closeEvent(QCloseEvent *event);
};

#endif // LOGIN_H
