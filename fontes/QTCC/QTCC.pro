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
    ui/conversas.cpp

HEADERS  += \
    ui/mainwindow.h \
    ui/conversas.h

FORMS    += ui/mainwindow.ui \
    ui/conversas.ui

CONFIG += mobility
MOBILITY = 

