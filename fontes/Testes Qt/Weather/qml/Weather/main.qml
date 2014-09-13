import QtQuick 2.0
import QtQuick.XmlListModel 2.0

Item {
    //Usar OpenWeatherMap, visto que a API do Google não funciona mais
    //ex: http://api.openweathermap.org/data/2.5/weather?q=London&mode=xml
    id: root
    /*
    property bool tempInC: true
    property string baseURL: "http://www.google.com"
    property string dataURL: "/ig/api?weather="
    // some other values: "de", "es", "fi", "fr", "it", "ru"
    property string language: "en"
    */

    property string location: "Munich"
    property string baseURL: "http://api.openweathermap.org"
    property string dataURL: "/data/2.5/"
    property string weatherURL: "weather?q="
    property string forecastURL: "forecast/daily?q="
    width: 300
    height: 700
    function f2C (tempInF) {
        return (5/9*(tempInF - 32)).toFixed(0)
    }
    /*
    XmlListModel {
        id: weatherModelCurrent
        source: baseURL + dataURL + location + "&hl=" + language
        query: "/xml_api_reply/weather/current_conditions"
        XmlRole { name: "condition"; query: "condition/@data/string()" }
        XmlRole { name: "temp_f"; query: "temp_f/@data/string()" }
        XmlRole { name: "humidity"; query: "humidity/@data/string()" }
        XmlRole { name: "icon_url"; query: "icon/@data/string()" }
        XmlRole { name: "wind_condition"; query: "wind_condition/@data/string()" }
    }
    Component {
        id: currentConditionDelegate
        Column {
            Text { text: qsTr("Today"); font.bold: true }
            Text { text: model.condition }
            Image { source: baseURL + model.icon_url }
            Text { text: model.temp_f + " F° / " + f2C (model.temp_f) + " C°" }
            Text { text: model.humidity }
            Text { text: model.wind_condition }
        }
    }
    XmlListModel {
        id: weatherModelForecast
        source: baseURL + dataURL + location + "&hl=" + language
        query: "/xml_api_reply/weather/forecast_conditions"
        XmlRole { name: "day_of_week"; query: "day_of_week/@data/string()" }
        XmlRole { name: "low"; query: "low/@data/string()" }
        XmlRole { name: "high"; query: "high/@data/string()" }
        XmlRole { name: "icon_url"; query: "icon/@data/string()" }
        XmlRole { name: "condition"; query: "condition/@data/string()" }
    }
    Component {
        id: forecastConditionDelegate
        Column {
            spacing: 2
            Text { text: model.day_of_week; font.bold: true }
            Text { text: model.condition }
            Image { source: baseURL + model.icon_url }
            Text { text: qsTr("Lows: ") +
                         model.low +
                         " F° / "
                         + f2C (model.low) + " C°"}
            Text { text: qsTr("Highs: ") +
                         model.high +
                         " F° / " +
                         f2C (model.high) + " C°"}
        }
    }
    Column {
        id: allWeather
        anchors.centerIn: parent
        anchors.margins: 10
        spacing: 10
        Repeater {
            id: currentReportList
            model: weatherModelCurrent
            delegate: currentConditionDelegate
        }
        /* we can use a GridView...* /
        GridView {
            id: forecastReportList
            width: 220
            height: 220
            cellWidth: 110; cellHeight: 110
            model: weatherModelForecast
            delegate: forecastConditionDelegate
        }
        /** /
        /* ..a Repeater
        Repeater {
            id: forecastReportList
            model: weatherModelForecast
            delegate: forecastConditionDelegate
        }
        * /
    }
    */
    XmlListModel {
        id: weatherModelCurrent
        source: baseURL + dataURL+ weatherURL + location + "&mode=xml"
        query: "/current"
        XmlRole {name: "temperature";query: "temperature/@value/string()"}
        XmlRole {name: "humidity";query: "humidity/@value/string()"}
        XmlRole {name:"weather";query:"weather/@value/string()";}
        XmlRole {name:"weather_icon";query:"weather/@icon/string()";}

//        XmlRole { name: "condition"; query: "condition/@data/string()" }
//        XmlRole { name: "temp_f"; query: "temp_f/@data/string()" }
//        XmlRole { name: "humidity"; query: "humidity/@data/string()" }
//        XmlRole { name: "icon_url"; query: "icon/@data/string()" }
//        XmlRole { name: "wind_condition"; query: "wind_condition/@data/string()" }
    }
    Component {
        id: currentConditionDelegate
        Column {
            Text { text: qsTr("Today"); font.bold: true }
            Text { text: model.weather }
            Image { source: "http://openweathermap.org/img/w/" + model.weather_icon + ".png" }
            Text { text: "Humidade: " + model.humidity + "%"}
            Text { text: (model.temperature - 273).toFixed(1) + " °C" }

//            Text { text: qsTr("Today"); font.bold: true }
//            Text { text: model.condition }
//            Image { source: baseURL + model.icon_url }
//            Text { text: model.temp_f + " F° / " + f2C (model.temp_f) + " C°" }
//            Text { text: model.humidity }
//            Text { text: model.wind_condition }
        }
    }
    XmlListModel {
        id: weatherModelForecast
        source: baseURL + dataURL + forecastURL + location + "&mode=xml&units=metric&cnt=7"
        query: "/weatherdata/forecast/time[position()>1]"
        XmlRole { name: "day"; query: "@day/string()" }
        XmlRole { name: "weather"; query: "symbol/@name/string()" }
        XmlRole { name: "weather_icon"; query: "symbol/@var/string()" }
        XmlRole { name: "low"; query: "temperature/@min/string()" }
        XmlRole { name: "max"; query: "temperature/@max/string()" }
        XmlRole { name: "avg"; query: "temperature/@day/string()" }

//        XmlRole { name: "day_of_week"; query: "day_of_week/@data/string()" }
//        XmlRole { name: "low"; query: "low/@data/string()" }
//        XmlRole { name: "high"; query: "high/@data/string()" }
//        XmlRole { name: "icon_url"; query: "icon/@data/string()" }
//        XmlRole { name: "condition"; query: "condition/@data/string()" }
    }
    Component {
        id: forecastConditionDelegate
        Column {
            spacing: 2
            Text { text: Qt.formatDate(model.day,"dd/MM");font.bold: true }
            Image { source: "http://openweathermap.org/img/w/" + model.weather_icon + ".png" }
            Text { text: model.weather }
            Text { text: "Temperatura: " + (model.avg-0).toFixed(1) + " °C" }
            Text { text: "Mínimo: " + (model.low-0).toFixed(1) + " °C" }
            Text { text: "Máximo: " + (model.max-0).toFixed(1) + " °C" }

//            Text { text: model.day_of_week; font.bold: true }
//            Text { text: model.condition }
//            Image { source: baseURL + model.icon_url }
//            Text { text: qsTr("Lows: ") +
//                         model.low +
//                         " F° / "
//                         + f2C (model.low) + " C°"}
//            Text { text: qsTr("Highs: ") +
//                         model.high +
//                         " F° / " +
//                         f2C (model.high) + " C°"}
        }
    }
    Column {
        id: allWeather
        anchors.centerIn: parent
        anchors.margins: 10
        spacing: 10
        Repeater {
            id: currentReportList
            model: weatherModelCurrent
            delegate: currentConditionDelegate
        }
        /* we can use a GridView...*/
        GridView {
            id: forecastReportList
            width: 220//220 //parent.width*0.9
            height: 220//220 //parent.height*0.9
            cellWidth: 110; cellHeight: 110
            model: weatherModelForecast
            delegate: forecastConditionDelegate
        }
        /*..a Repeater*/
        /*
        Repeater {
            id: forecastReportList
            model: weatherModelForecast
            delegate: forecastConditionDelegate
        }
        */
    }
    MouseArea {
        anchors.fill: parent
        onClicked: Qt.quit()
    }
}
