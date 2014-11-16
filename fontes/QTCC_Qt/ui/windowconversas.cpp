#include "windowconversas.h"
#include "ui_windowconversas.h"

WindowConversas::WindowConversas(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowConversas)
{
    ui->setupUi(this);
}

WindowConversas::~WindowConversas()
{
    delete ui;
}

void WindowConversas::on_listConversas_itemClicked(QListWidgetItem *item)
{

}

void WindowConversas::on_actionNova_Conversa_triggered()
{

}

void WindowConversas::on_actionLogout_triggered()
{

}
