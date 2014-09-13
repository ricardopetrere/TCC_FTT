import QtQuick 2.0
// this will be a component later
Rectangle {
    id: root
    property bool showDate: true
    property bool showSeconds: true
    property string currentTime: "23:59"
    property string currentDate: "31.12.12"
    // the sizes are in proportion to the hight of the clock.
    // There are three borders, text and date.
    // 3*borderProportion+timeTextProportion+dateTextProportion has to be 1.0
    property real borderProportion: 0.1
    property real timeTextProportion: 0.5
    property real dateTextProportion: 0.2
    property string textColor: "red"
    height:240
    width:400
    Image {
        id: background
        source: "../content/resources/light_background.png"
        fillMode: "Tile"
        anchors.fill: parent
        onStatusChanged: if (background.status == Image.Error)
                             console.log (qsTr("Background image \"") +
                                          source +
                                          qsTr("\" cannot be loaded"))
    }
    FontLoader {
        id: ledFont
        source: "../content/resources/font/LED_REAL.TTF"
        onStatusChanged: if (ledFont.status == FontLoader.Error)
                             console.log (qsTr("Font \"") +
                                          source +
                                          qsTr("\" cannot be loaded"))
    }
    Column {
        id: clockText
        anchors.centerIn: parent
        spacing: root.height*root.borderProportion
        Text {
            id: timeText
            text: root.currentTime
            font.pixelSize: root.height*root.timeTextProportion
            font.family: ledFont.name // use "Series 60 ZDigi" on Symbian instead
            font.bold: true
            color: root.textColor
            style: Text.Raised
            styleColor: "black"
        }
        Text {
            id: dateText
            text: currentDate
            color: textColor
            anchors.horizontalCenter: parent.horizontalCenter
            font.family: ledFont.name // use "Series 60 ZDigi" on Symbian instead
            font.pixelSize: root.height*root.dateTextProportion
            visible: showDate
            style: Text.Raised
            styleColor: "black"
        }
    }
}
