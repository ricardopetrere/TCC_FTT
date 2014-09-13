import QtQuick 2.0

Rectangle {
    id: root
    width: 80
    height: 80
    color: "lightgrey"
/*
        Text {
            id: timeText
            anchors.top: root.top
            anchors.horizontalCenter: parent.horizontalCenter
            //anchors.right: root.right
            anchors.margins: 10
            text: "13:45"
        }
        Text {
            id: dateText
            anchors.bottom: root.bottom
            anchors.horizontalCenter: parent.horizontalCenter
            anchors.margins: 10
            text: "23.02.2012"
        }
*/
    Column{
        id:clockText
        anchors.centerIn: root
        spacing: 20
        Text {
            id: timeText
            anchors.horizontalCenter: parent.horizontalCenter
            text: "13:45"
        }
        Text {
            id: dateText
            anchors.horizontalCenter: parent.horizontalCenter
            text: "23.02.2012"
        }
    }

    MouseArea {
        anchors.fill: root
        onClicked: {
        Qt.quit();
        }
    }
}
