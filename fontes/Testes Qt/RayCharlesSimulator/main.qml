import QtQuick 2.2
import QtQuick.Window 2.1

Window {
    visible: true
    color: "black"
    width: 360
    height: 360
    title: "Simulador de Ray Charles"
    /*
    MouseArea {
        anchors.fill: parent
        onClicked: {
            Qt.quit();
        }
    }
    */
    Column{
        MouseArea{
            id:btnDo
            anchors.centerIn: parent
        }
        MouseArea{
            id:btnRe
            anchors.centerIn: parent
        }
        MouseArea{
            id:btnMi
            anchors.centerIn: parent
        }
        MouseArea{
            id:btnFa
            anchors.centerIn: parent
        }
        MouseArea{
            id:btnSol
            anchors.centerIn: parent
        }
        MouseArea{
            id:btnLa
            anchors.centerIn: parent
        }
        MouseArea{
            id:btnSi
            anchors.centerIn: parent
        }
    }
}
