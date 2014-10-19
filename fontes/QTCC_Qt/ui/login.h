#ifndef LOGIN_H
#define LOGIN_H

#include <QMainWindow>
//#include <QWidget>

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
        qDebug(login.toLatin1());
        return login!="";
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
        login="";
    }

private slots:
    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

private:
    Ui::Login *ui;
    static QString login;

};

#endif // LOGIN_H
