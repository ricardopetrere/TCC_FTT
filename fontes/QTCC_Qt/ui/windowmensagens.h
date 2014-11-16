#ifndef WINDOWMENSAGENS_H
#define WINDOWMENSAGENS_H

#include <QMainWindow>

namespace Ui {
class WindowMensagens;
}

class WindowMensagens : public QMainWindow
{
    Q_OBJECT

public:
    explicit WindowMensagens(QWidget *parent = 0);
    ~WindowMensagens();

private slots:
    void on_btnEnviar_clicked();

private:
    Ui::WindowMensagens *ui;
};

#endif // WINDOWMENSAGENS_H
