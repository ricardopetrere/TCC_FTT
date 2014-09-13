import QtQuick 2.0

Rectangle {
    width: 360
    height: 360
    Text {
    anchors.centerIn: parent
    text: "Hello World! My size is " +
    parent.width + " x " + parent.height + "!"
    }
    onHeightChanged: print ("new size: ", width, "x", height)
    MouseArea {
        anchors.fill: parent
        onClicked: {
            Qt.quit();
        }
    }
}
