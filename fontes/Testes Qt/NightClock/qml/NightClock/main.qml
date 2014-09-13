import QtQuick 2.0

Rectangle {
    id: root

    property bool showDate: true
    property bool showSeconds: true
    property string currentTime
    property string currentDate
    // the sizes are in proportion to the hight of the clock.
    // There are three borders, text and date.
    // 3*borderProportion+timeTextProportion+dateTextProportion has to be 1.0
    property real borderProportion: 0.1
    property real timeTextProportion: 0.5
    property real dateTextProportion: 0.2
    property string textColor: "red"
    property string timeFormat: "hh :mm"
    property string dateFormat: "dd/MM/yy"

    height:320
    width:635

    color: "transparent"

    // returns formated time and date
    function getFormattedDateTime(format) {
        var date = new Date
        return Qt.formatDateTime(date, format)
    }

    function updateTime() {
        root.currentTime = "<big>" +
                getFormattedDateTime(timeFormat) +
                "</big>" +
                (showSeconds ? "<sup><small> " + getFormattedDateTime("ss") +
                               "</small></sup>" : "");
        root.currentDate = getFormattedDateTime(dateFormat);
    }

    Image {
        id: background
        source: "../content/resources/background.png"
        fillMode: "Tile"
        anchors.fill: parent
        onStatusChanged: if (background.status == Image.Error)
                             console.log (qsTr("Background image \"") +
                                          source +
                                          qsTr("\" cannot be loaded"))
    }

    FontLoader {
        id: ledFont
        // unfortunately, the font will not load on a Symbian device,
        // and the default font will be used:
        // http://bugreports.qt-project.org/browse/QTBUG-6611
        // The bug should be fixed in 4.8
        source: "../content/resources/font/LED_REAL.TTF"
        onStatusChanged: if (ledFont.status == FontLoader.Error)
                             console.log("Font \"" + source + "\" cannot be loaded")
    }

    Timer {
        id: updateTimer
        running: Qt.application.active && visible == true
        repeat: true
        triggeredOnStart: true
        onTriggered: {
            updateTime()
            // refresh the interval to update the time each second or minute.
            // consider the delta in order to update on a full minute
            interval = 1000*(showSeconds? 1 : (60 - getFormattedDateTime("ss")))
        }
    }

    // trigger an update if the showSeconds setting has changed
    onShowSecondsChanged: {
        updateTime()
    }

    Column {
        id: clockText
        anchors.centerIn: parent
        spacing: root.height*root.borderProportion

        Text {
            id: timeText
            textFormat: Text.RichText
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
            text: root.currentDate
            color: root.textColor
            anchors.horizontalCenter: parent.horizontalCenter
            font.family: ledFont.name // use "Series 60 ZDigi" on Symbian instead
            font.pixelSize: root.height*root.dateTextProportion
            visible: root.showDate
            style: Text.Raised
            styleColor: "black"
        }
        Rectangle{
            height:20
            width:100
            color: "blue"
            id:btnHabilitarSegundos
            anchors.horizontalCenter: parent.horizontalCenter
            property string texto1:qsTr("Habilitar Segundos")
            property string texto2:qsTr("Desabilitar Segundos")
            Text{
                id:txtHabilitarSegundos
                anchors.centerIn: parent
                text: (!showSeconds?parent.texto1:parent.texto2)
            }

            MouseArea{
                id:btnHabilitarSegundos_click
                anchors.fill: parent
                onClicked:{
                    showSeconds=!showSeconds
                    txtHabilitarSegundos.text = (!showSeconds?parent.texto1:parent.texto2)
                }
            }
        }
        Rectangle{
            height:20
            width:100
            color: "blue"
            id:btnHabilitarData
            anchors.horizontalCenter: parent.horizontalCenter
            property string texto1:qsTr("Habilitar Data")
            property string texto2:qsTr("Desabilitar Data")
            Text{
                id:txtHabilitarData
                anchors.centerIn: parent
                text: (!showDate?parent.texto1:parent.texto2)
            }

            MouseArea{
                id:btnHabilitarData_click
                anchors.fill: parent
                onClicked:{
                    showDate=!showDate
                    txtHabilitarData.text = (!showDate?parent.texto1:parent.texto2)
                }
            }
        }
    }
}
