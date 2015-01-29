#-------------------------------------------------
#
# Project created by QtCreator 2014-10-01T21:30:20
#
#-------------------------------------------------

QT       += core
QT       += network

QT       -= gui

TARGET = MyServer
CONFIG   += console
CONFIG   -= app_bundle

TEMPLATE = app


SOURCES += main.cpp \
    serversocket.cpp

HEADERS += \
    serversocket.h
