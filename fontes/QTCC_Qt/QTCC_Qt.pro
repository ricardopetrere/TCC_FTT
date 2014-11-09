#-------------------------------------------------
#
# Project created by QtCreator 2014-10-13T22:00:05
#
#-------------------------------------------------

QT       += core gui network

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = QTCC_Qt
TEMPLATE = app


SOURCES += main.cpp \
    ui/mainwindow.cpp \
    ui/conversas.cpp \
    ui/contatos.cpp \
    ngc/historicoconversa.cpp \
    ui/mensagens.cpp \
    ui/login.cpp \
    ui/cadastre_se.cpp \
    vo/ebase.cpp \
    vo/emensagem.cpp \
    vo/econtato.cpp \
    vo/eusuario.cpp \
    util/comunicacaorede.cpp \
    vo/constantes.cpp \
    controller/usuariocontroller.cpp \
    vo/erequisicaologin.cpp \
    controller/requisicaologincontroller.cpp \
    controller/mensagemcontroller.cpp \
    controls/contatowidget.cpp

HEADERS  += \
    ui/mainwindow.h \
    ui/conversas.h \
    ui/contatos.h \
    ngc/historicoconversa.h \
    ui/mensagens.h \
    ui/login.h \
    ui/cadastre_se.h \
    ngc/logger.h \
    vo/ebase.h \
    vo/emensagem.h \
    vo/econtato.h \
    vo/eusuario.h \
    util/comunicacaorede.h \
    vo/constantes.h \
    controller/usuariocontroller.h \
    vo/erequisicaologin.h \
    controller/requisicaologincontroller.h \
    controller/mensagemcontroller.h \
    controls/contatowidget.h

FORMS    += ui/mainwindow.ui \
    ui/conversas.ui \
    ui/contatos.ui \
    ui/mensagens.ui \
    ui/login.ui \
    ui/cadastre_se.ui \
    controls/contatowidget.ui \
    controls/mensagem.ui \
    controls/mensagem_de.ui

CONFIG += mobility
MOBILITY = 

RESOURCES += \
    QTCC_Qt.qrc

