#ifndef WINDOWCONTATOS_H
#define WINDOWCONTATOS_H

#include <QMainWindow>
#include <QListWidgetItem>

namespace Ui {
class WindowContatos;
}

class WindowContatos : public QMainWindow
{
    Q_OBJECT

public:
    explicit WindowContatos(QWidget *parent = 0);
    ~WindowContatos();

    void lerContatos();
private slots:
    void on_listContatos_itemClicked(QListWidgetItem *item);

    void on_listContatos_customContextMenuRequested(const QPoint &pos);

    void on_actionNovoContato_triggered();

private:
    Ui::WindowContatos *ui;
};

#endif // WINDOWCONTATOS_H
