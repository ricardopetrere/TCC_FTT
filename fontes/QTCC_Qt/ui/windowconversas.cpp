#include "windowconversas.h"
#include "ui_windowconversas.h"
#include "windowmensagens.h"
#include "windowcontatos.h"
#include "dialoglogin.h"

#include <util/logger.h>

#include <controller/contatocontroller.h>
#include <controller/conversacontroller.h>
#include <controller/usuariocontroller.h>

WindowConversas::WindowConversas(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowConversas)
{
    ui->setupUi(this);
    ui->listConversas->clear();
    carregaDadosUsuario();
}

WindowConversas::~WindowConversas()
{
    delete ui;
}

void WindowConversas::on_listConversas_itemClicked(QListWidgetItem *item)
{
    Logger::debug(item->text(), " Clicado.");
    WindowMensagens *m = new WindowMensagens(this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void WindowConversas::on_actionNova_Conversa_triggered()
{
    Logger::debug("Nova Conversa.");
    WindowContatos *c = new WindowContatos(this);
    c->setWindowModality(Qt::WindowModal);
    c->show();
}

void WindowConversas::on_actionLogout_triggered()
{
    Logger::debug("Login/Logout.");
    if(UsuarioController::estaLogado())
    {
        ui->actionNova_Conversa->setEnabled(false);
        UsuarioController::realizaLogout();
    }
    carregaDadosUsuario();
}

void WindowConversas::on_listConversas_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listConversas->itemAt(pos)!=NULL)
        Logger::debug(ui->listConversas->itemAt(pos)->text(), " contextMenu.");
    else
        Logger::debug(windowTitle()," contextMenu");
}

void WindowConversas::carregaDadosUsuario()
{
    DialogLogin::validaLogin(true,0);
    if(UsuarioController::estaLogado())
    {
        ui->actionNova_Conversa->setEnabled(true);
        UsuarioController::lerContatosUsuarioLogado();
        ConversaController::_usuario_conversas = ConversaController::lerConversasUsuarioLogado();
        foreach (EConversa conversa, ConversaController::_usuario_conversas)
        {
            ui->listConversas->addItem(conversa.contato().Nome());
        }
    }
}
