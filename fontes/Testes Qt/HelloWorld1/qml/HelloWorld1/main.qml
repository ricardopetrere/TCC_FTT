import QtQuick 2.0

Rectangle {
    width: 360
    height: 360
    Text {
        text: qsTr("Hello World")
        anchors.centerIn: parent
    }
    onWidthChanged: console.log("Largura atual: ",width)
    onHeightChanged:console.trace()
    MouseArea {
        id: ma
        anchors.fill: parent
        acceptedButtons: Qt.LeftButton|Qt.RightButton|Qt.MiddleButton
        onClicked: {
            Qt.quit();
        }
    }
}
