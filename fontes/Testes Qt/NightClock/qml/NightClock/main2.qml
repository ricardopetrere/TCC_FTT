import QtQuick 2.0
import "../../js/style.js" as Style
import "../../js/logic.js" as Logic

Rectangle {
    id: root
    property bool showDate: true
    property bool showSeconds: true
    property string currentTime
    property string currentDate
    property string textColor: "green"
    //height:120
    //width:300
    height:320
    width:635
    color: "transparent"
    function updateScreen(){
        updateTime()
        // refresh the interval to update the time each second or minute.
        // consider the delta in order to update on a full minute
        updateTimer.interval = 1000*(showSeconds? 1 : (60 - Logic.getFormattedDateTime("ss")))
    }

    function updateTime() {
        root.currentTime = "<big>" + Logic.getFormattedDateTime(Style.timeFormat) + "</big>" +
                (showSeconds ? "<sup><small> " + Logic.getFormattedDateTime("ss") + "</small></sup>":"")
        root.currentDate = (showDate?Logic.getFormattedDateTime(Style.dateFormat):"");
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
            updateScreen()
        }
    }
    // trigger an update if the showSeconds setting has changed
    onShowSecondsChanged: {
        updateScreen()
    }
    onShowDateChanged: updateScreen()

    Column {
        id: clockText
        anchors.centerIn: parent
        spacing: root.height*Style.borderProportion
        Text {
            id: timeText
            textFormat: Text.RichText
            text: root.currentTime
            font.pixelSize: root.height*Style.timeTextProportion
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
            font.pixelSize: root.height*Style.dateTextProportion
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
