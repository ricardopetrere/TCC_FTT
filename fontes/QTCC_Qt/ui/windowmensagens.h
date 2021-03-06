#ifndef WINDOWMENSAGENS_H
#define WINDOWMENSAGENS_H

#include <QMainWindow>
#include <controller/conversacontroller.h>
#include <QThread>

namespace Ui {
class WindowMensagens;
}

class WindowMensagens : public QMainWindow
{
    Q_OBJECT

public:

    ~WindowMensagens();
    explicit WindowMensagens(EConversa* conversa,QWidget *parent=0);
    void lerMensagens();
    bool enviarMensagemParaServidor(EMensagem m);
private slots:
    void on_btnEnviar_clicked();

    void on_listMensagens_customContextMenuRequested(const QPoint &pos);

private:
    QThread receberMensagensThread;
    explicit WindowMensagens(QWidget *parent = 0);
    Ui::WindowMensagens *ui;
    EConversa* _conversa;
    QColor cor_EntregaPendente = QColor::fromRgb(250,250,150);
    QColor cor_Enviado = QColor::fromRgb(180,180,255);
    QColor cor_RecebidoNoDestino = QColor::fromRgb(178,248,157);
    QColor cor_Recebido = QColor::fromRgb(221,221,221);
};

#endif // WINDOWMENSAGENS_H
