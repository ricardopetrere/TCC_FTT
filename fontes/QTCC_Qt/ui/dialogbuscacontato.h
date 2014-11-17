#ifndef DIALOGBUSCACONTATO_H
#define DIALOGBUSCACONTATO_H

#include <QDialog>

namespace Ui {
class DialogBuscaContato;
}

class DialogBuscaContato : public QDialog
{
    Q_OBJECT

public:
    explicit DialogBuscaContato(QWidget *parent = 0);
    explicit DialogBuscaContato(QString mensagem_sobre_pesquisa,QString texto_pushbutton,QString titulo,QWidget *parent = 0);
    ~DialogBuscaContato();
    QString pesquisado;
private slots:
    void on_btnBuscarContato_clicked();
private:
    Ui::DialogBuscaContato *ui;
};

#endif // DIALOGBUSCACONTATO_H
