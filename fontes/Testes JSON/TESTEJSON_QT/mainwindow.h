#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

#include <QJsonObject>
#include <QList>

#include "user.h"
#include "message.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

    void read(const QJsonObject &json);
    void write(QJsonObject &json) const;

private slots:
    void on_btnSerializar_clicked();

    void on_btnDeserializar_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
