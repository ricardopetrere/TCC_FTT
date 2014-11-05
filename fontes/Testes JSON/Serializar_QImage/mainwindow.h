#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

    void write(QJsonObject &json) const;
    void read(const QJsonObject &json);
private slots:
    void on_btnEscolherImagem_clicked();

    void on_btnSerializar_clicked();

    void on_btnDeserializar_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
