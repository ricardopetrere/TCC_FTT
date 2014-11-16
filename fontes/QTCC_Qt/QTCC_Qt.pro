#-------------------------------------------------
#
# Project created by QtCreator 2014-11-12T18:49:08
#
#-------------------------------------------------

QT       += core gui network

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = QTCC_Qt
TEMPLATE = app


SOURCES += main.cpp \
    util/comunicacaorede.cpp \
    controller/mensagemcontroller.cpp \
    controller/requisicaologincontroller.cpp \
    controller/usuariocontroller.cpp \
    vo/constantes.cpp \
    vo/ebase.cpp \
    vo/econtato.cpp \
    vo/econversa.cpp \
    vo/emensagem.cpp \
    vo/erequisicaologin.cpp \
    vo/eusuario.cpp \
    ui/dialoglogin.cpp \
    ui/dialogcadastre_se.cpp \
    ui/windowconversas.cpp \
    ui/windowcontatos.cpp \
    ui/windowmensagens.cpp

HEADERS  += \
    controller/mensagemcontroller.h \
    controller/requisicaologincontroller.h \
    controller/usuariocontroller.h \
    util/logger.h \
    util/comunicacaorede.h \
    util/InteracaoArquivo.h \
    vo/constantes.h \
    vo/ebase.h \
    vo/econtato.h \
    vo/econversa.h \
    vo/emensagem.h \
    vo/erequisicaologin.h \
    vo/eusuario.h \
    ui/dialoglogin.h \
    ui/dialogcadastre_se.h \
    ui/windowconversas.h \
    ui/windowcontatos.h \
    ui/windowmensagens.h

FORMS    += \
    ui/dialoglogin.ui \
    ui/dialogcadastre_se.ui \
    ui/windowconversas.ui \
    ui/windowcontatos.ui \
    ui/windowmensagens.ui

RESOURCES += \
    QTCC_Images.qrc
