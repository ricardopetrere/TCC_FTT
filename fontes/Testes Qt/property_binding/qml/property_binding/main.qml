import QtQuick 2.0

Rectangle {
    id: root

    property int adaptiveSize: root.width/10

    width: 100
    height: 100
    onAdaptiveSizeChanged: text2.font.pixelSize=adaptiveSize
    Text {
        id: text1
        anchors.centerIn: parent
        text: "initial text"
        onTextChanged: {
            console.log ("text 1 is changed: " + text1.text)
        }
    }

    Text {
        id: text2
        anchors.top: text1.bottom
        anchors.horizontalCenter: text1.horizontalCenter
        text: text1.text
        //font.pixelSize: adaptiveSize
        onTextChanged: {
            console.log ("text 2 is changed: " + text2.text)
        }
    }

    MouseArea {
        anchors.fill: parent
        onClicked: {
            text1.text = "new text"
            console.log ("text 1 is now: " + text1.text)
            console.log ("text 2 is now: " + text2.text)
        }
    }
}

