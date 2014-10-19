#ifndef CADASTRE_SE_H
#define CADASTRE_SE_H

#include <QMainWindow>

namespace Ui {
class Cadastre_se;
}

class Cadastre_se : public QMainWindow
{
    Q_OBJECT

public:
    explicit Cadastre_se(QWidget *parent = 0);
    ~Cadastre_se();

private slots:
    void on_pushButton_clicked();

    void on_pushButton_2_clicked();

    void on_pushButton_3_clicked();

private:
    Ui::Cadastre_se *ui;
};

#endif // CADASTRE_SE_H
