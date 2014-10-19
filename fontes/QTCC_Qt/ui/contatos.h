#ifndef CONTATOS_H
#define CONTATOS_H

#include <QMainWindow>
#include <QListWidgetItem>

namespace Ui {
class Contatos;
}

class Contatos : public QMainWindow
{
    Q_OBJECT

public:
    explicit Contatos(QWidget *parent = 0);
    ~Contatos();

private slots:
    void on_listWidget_itemClicked(QListWidgetItem *item);

    void on_listWidget_itemDoubleClicked(QListWidgetItem *item);

    void on_listWidget_itemPressed(QListWidgetItem *item);

    void on_listWidget_customContextMenuRequested(const QPoint &pos);

    void on_listWidget_clicked(const QModelIndex &index);

private:
    Ui::Contatos *ui;
};

#endif // CONTATOS_H
