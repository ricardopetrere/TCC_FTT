#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
//#include <vo/eusuario.h>
//#include <vo/econversa.h>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
//    static EUsuario _usuario_logado;
//    static QList<EContato> _usuario_contatos;
//    static QList<EConversa> _usuario_conversas;
//    static bool estaLogado()
//    {
//        return _usuario_logado.Id()!=-1;
//    }
//    static void lerContatos()
//    {
//        _usuario_contatos = EContato::lerContatos(_usuario_logado.Id());
//    }
//    static void lerConversas()
//    {
//        _usuario_conversas = EConversa::lerConversas(_usuario_logado.Id());
//    }

private slots:
    void on_actionLogout_triggered();

    void on_actionExibir_Conversas_triggered();

signals:

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
