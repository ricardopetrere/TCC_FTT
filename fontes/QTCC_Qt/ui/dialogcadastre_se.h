#ifndef DIALOGCADASTRE_SE_H
#define DIALOGCADASTRE_SE_H

#include <QDialog>

namespace Ui {
class DialogCadastre_se;
}

class DialogCadastre_se : public QDialog
{
    Q_OBJECT

public:
    explicit DialogCadastre_se(QWidget *parent = 0);
    ~DialogCadastre_se();

private slots:
    void on_btnEscolhaImagem_clicked();

    void on_btnCancelar_clicked();

    void on_btnCadastrar_clicked();

private:
    Ui::DialogCadastre_se *ui;
};

#endif // DIALOGCADASTRE_SE_H
