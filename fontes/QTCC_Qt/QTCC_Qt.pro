#-------------------------------------------------
#
# Project created by QtCreator 2014-10-13T22:00:05
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = QTCC
TEMPLATE = app


SOURCES += main.cpp \
    ui/mainwindow.cpp \
    ui/conversas.cpp \
    ui/contatos.cpp \
    ngc/contato.cpp \
    ngc/historicoconversa.cpp \
    ui/mensagens.cpp \
    ui/login.cpp \
    ui/cadastre_se.cpp \
    ngc/logger.cpp

HEADERS  += \
    ui/mainwindow.h \
    ui/conversas.h \
    ui/contatos.h \
    ngc/contato.h \
    ngc/historicoconversa.h \
    ui/mensagens.h \
    ui/login.h \
    ui/cadastre_se.h \
    ngc/logger.h

FORMS    += ui/mainwindow.ui \
    ui/conversas.ui \
    ui/contatos.ui \
    ui/mensagens.ui \
    ui/login.ui \
    ui/cadastre_se.ui

CONFIG += mobility
MOBILITY = 
