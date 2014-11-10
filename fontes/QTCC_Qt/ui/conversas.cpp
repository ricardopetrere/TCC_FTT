#include "conversas.h"
#include "ui_conversas.h"
#include "contatos.h"
#include "mensagens.h"
//#include "ngc/logger.h"
//#include "mainwindow.h"
//#include "login.h"
//#include "ui_conversawidget.h"
//#include "ui_mensagem_enviada.h"
//#include "ui_mensagem_recebida.h"
#include "ui/dialoglogin.h"

Conversas::Conversas(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::Conversas)
{
    ui->setupUi(this);
    carregaDadosUsuario();
}

Conversas::~Conversas()
{
    delete ui;
}

void Conversas::on_listConversas_itemClicked(QListWidgetItem *item)
{
    Logger::debug(item->text(), " Clicado.");
    Mensagens *m = new Mensagens(this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void Conversas::on_actionNova_Conversa_triggered()
{
    Logger::debug("Nova Conversa.");
    Contatos *c = new Contatos(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
}

void Conversas::on_listConversas_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listConversas->SelectRows!=0)
        Logger::debug(ui->listConversas->selectedItems()[0]->text(), " contextMenu.");
}

void Conversas::on_actionLogout_triggered()
{
    Logger::debug("Login/Logout.");
    DialogLogin *l = new DialogLogin(this);
    if(DialogLogin::estaLogado())
    {
        DialogLogin::realizaLogout();
    }
    l->exec();
}

void Conversas::carregaDadosUsuario()
{
    DialogLogin::validaLogin(true,0);
    ui->listConversas->clear();
    if(DialogLogin::estaLogado())
    {
        MainWindow::_usuario_contatos = EContato::lerContatos(MainWindow::_usuario_logado.Id());
        MainWindow::_usuario_conversas = EConversa::lerConversas(MainWindow::_usuario_logado.Id());
    }
}
