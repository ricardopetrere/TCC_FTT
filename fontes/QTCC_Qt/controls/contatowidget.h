#ifndef CONTATOWIDGET_H
#define CONTATOWIDGET_H

#include <QWidget>

namespace Ui {
class ContatoWidget;
}

class ContatoWidget : public QWidget
{
    Q_OBJECT

public:
    explicit ContatoWidget(QWidget *parent = 0);
    ~ContatoWidget();

private:
    Ui::ContatoWidget *ui;
};

#endif // CONTATOWIDGET_H
