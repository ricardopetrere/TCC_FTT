#include "windowcontatos.h"
#include "ui_windowcontatos.h"
#include "windowmensagens.h"
#include "dialogbuscacontato.h"

#include <util/logger.h>

#include <controller/usuariocontroller.h>

WindowContatos::WindowContatos(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::WindowContatos)
{
    ui->setupUi(this);
    lerContatos();
}

WindowContatos::~WindowContatos()
{
    delete ui;
}

void WindowContatos::on_listContatos_itemClicked(QListWidgetItem *item)
{
    Logger::debug(item->text(), " Clicado.");
    WindowMensagens *m = new WindowMensagens(ConversaController::defineConversaSelecionada(item->text()),this);
    m->setWindowModality(Qt::WindowModal);
    m->show();
    m->setWindowTitle(item->text());
}

void WindowContatos::on_listContatos_customContextMenuRequested(const QPoint &pos)
{
    if(ui->listContatos->itemAt(pos)!=NULL)
        Logger::debug(ui->listContatos->itemAt(pos)->text(), " contextMenu.");
    else
        Logger::debug(windowTitle()," contextMenu");
}

void WindowContatos::on_actionNovoContato_triggered()
{
    DialogBuscaContato *b = new DialogBuscaContato("Insira o e-mail do contato a ser adicionado","Adicionar","Adicionar Contato",this);
    b->exec();
    if(!b->pesquisado.isEmpty())
    {
        EUsuario u = UsuarioController::buscaUsuarioPeloEmail(b->pesquisado);
        if(u.Id()>0)
        {
            ContatoController::_usuario_contatos.append(u);
            UsuarioController::EnviarNovoUsuario(u);
            UsuarioController::salvarContatosUsuarioLogado();
            lerContatos();
        }
    }
}
void WindowContatos::lerContatos()
{
    ui->listContatos->clear();
    foreach (EContato contato, ContatoController::_usuario_contatos) {
        ui->listContatos->addItem(contato.Nome());
    }
}
