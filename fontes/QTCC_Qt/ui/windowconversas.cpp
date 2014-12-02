#include "windowconversas.h"
#include "ui_windowconversas.h"
#include "windowmensagens.h"
#include "windowcontatos.h"
#include "dialoglogin.h"
#include <QThread>

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
    l = new LerMensagensController(this);
    carregaDadosUsuario();
}

WindowConversas::~WindowConversas()
{
    delete ui;
}

void WindowConversas::on_listConversas_itemClicked(QListWidgetItem *item)
{
    Logger::debug(item->text(), " Clicado.");
    WindowMensagens *m = new WindowMensagens(ConversaController::defineConversaSelecionada(item->text()),this);
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
        if(!l->workerThread.isFinished())
            l->workerThread.quit();
        ui->actionNova_Conversa->setEnabled(false);
        ui->listConversas->clear();
        ConversaController::_usuario_conversas = new QList<EConversa>();
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

void WindowConversas::receberNovasMensagens()
{
    *ConversaController::_usuario_conversas = ConversaController::lerConversasUsuarioLogado();
    emit l->operate("");
    foreach (EConversa conversa, *ConversaController::_usuario_conversas)
    {
        ui->listConversas->addItem(conversa.contato().Nome());
    }
}

void WindowConversas::carregaDadosUsuario()
{
    DialogLogin::validaLogin(true,0);
    if(UsuarioController::estaLogado())
    {
        if(!l->workerThread.isRunning())
        {
            delete l;
            l = new LerMensagensController(this);
//            l->workerThread.start();
        }
        ui->actionNova_Conversa->setEnabled(true);
        UsuarioController::lerContatosUsuarioLogado();
        receberNovasMensagens();
    }
}
