import QtQuick 2.0

Rectangle {
    width: 480
    height: 300
    property string url_original:""
    property string url_codificada:""

    Text {
        x: 25
        y: 36
        text: "Insira o URL:"
        font.pointSize: 12
    }

    Text {
        x: 25
        y: 140
        text: "Resultado:"
        font.pointSize: 12
    }

    Rectangle {
        id: rec_url_original
        x: 25
        y: 61
        width: 425
        height: 19
        color: "#ffffff"
        radius: 0
        border.width: 1
        border.color: "#000000"
        Flickable {
             id: flick

             anchors.fill: parent
             contentWidth: txt_url_original.paintedWidth
             contentHeight: txt_url_original.paintedHeight
             clip: true

             function ensureVisible(r)
             {
                 if (contentX >= r.x)
                     contentX = r.x;
                 else if (contentX+width <= r.x+r.width)
                     contentX = r.x+r.width-width;
                 if (contentY >= r.y)
                     contentY = r.y;
                 else if (contentY+height <= r.y+r.height)
                     contentY = r.y+r.height-height;
             }

             TextEdit {
                 id: txt_url_original
                 width: flick.width
                 height: flick.height
                 focus: true
                 onCursorRectangleChanged: flick.ensureVisible(cursorRectangle)
             }
         }
//        TextEdit {
//            id: txt_url_original
//            anchors.fill: parent
//            font.pointSize: 12
//            focus: true
//            clip: true
//        }
    }

    Rectangle {
        id: btn_codificar
        x: 25
        y: 96
        width: 112
        height: 21
        color: "#b7b2f1"
        border.color: "#0000ff"

        Text {
            anchors.centerIn: parent
            text: "Codificar"
            font.pointSize: 12
        }

        MouseArea {
            anchors.fill: parent
            onClicked: {
                url_original = txt_url_original.text
                url_codificada = url_original


            }
        }
    }

    Rectangle {
        id: btn_decodificar
        x: 338
        y: 96
        width: 112
        height: 21
        color: "#b6b1f2"
        border.color: "#0500ff"

        Text {
            anchors.centerIn: parent
            text: "Decodificar"
            font.pointSize: 12
        }

        MouseArea {
            anchors.fill: parent
            onClicked: {
                url_original = txt_url_original.text
                url_codificada = url_original

                //http://stackoverflow.com/a/1145525

                //bloco do %2
                url_codificada = url_codificada.split("%20").join(" ")
                url_codificada = url_codificada.split("%21").join("!")
                url_codificada = url_codificada.split("%22").join("\"")
                url_codificada = url_codificada.split("%23").join("#")
                url_codificada = url_codificada.split("%24").join("$")
                url_codificada = url_codificada.split("%25").join("%")
                url_codificada = url_codificada.split("%26").join("&")
                url_codificada = url_codificada.split("%27").join("\'")
                url_codificada = url_codificada.split("%28").join("(")
                url_codificada = url_codificada.split("%29").join(")")
                url_codificada = url_codificada.split("%2A").join("*")
                url_codificada = url_codificada.split("%2B").join("+")
                url_codificada = url_codificada.split("%2C").join(",")
                url_codificada = url_codificada.split("%2D").join("-")
                url_codificada = url_codificada.split("%2E").join(".")
                url_codificada = url_codificada.split("%2F").join("/")

                //bloco do %3
                url_codificada = url_codificada.split("%30").join("0")
                url_codificada = url_codificada.split("%31").join("1")
                url_codificada = url_codificada.split("%32").join("2")
                url_codificada = url_codificada.split("%33").join("3")
                url_codificada = url_codificada.split("%34").join("4")
                url_codificada = url_codificada.split("%35").join("5")
                url_codificada = url_codificada.split("%36").join("6")
                url_codificada = url_codificada.split("%37").join("7")
                url_codificada = url_codificada.split("%38").join("8")
                url_codificada = url_codificada.split("%39").join("9")
                url_codificada = url_codificada.split("%3A").join(":")
                url_codificada = url_codificada.split("%3B").join(";")
                url_codificada = url_codificada.split("%3C").join("<")
                url_codificada = url_codificada.split("%3D").join("=")
                url_codificada = url_codificada.split("%3E").join(">")
                url_codificada = url_codificada.split("%3F").join("?")

                txt_url_codificada.text=url_codificada
            }
        }
    }

    Rectangle {
        id: rec_url_codificada
        x: 25
        y: 165
        width: 425
        height: 19
        color: "#ffffff"
        border.color: "#000000"
        Flickable {
             id: flick2

             anchors.fill: parent
             contentWidth: txt_url_codificada.paintedWidth
             contentHeight: txt_url_codificada.paintedHeight
             clip: true

             function ensureVisible(r)
             {
                 if (contentX >= r.x)
                     contentX = r.x;
                 else if (contentX+width <= r.x+r.width)
                     contentX = r.x+r.width-width;
                 if (contentY >= r.y)
                     contentY = r.y;
                 else if (contentY+height <= r.y+r.height)
                     contentY = r.y+r.height-height;
             }

             TextEdit {
                 id: txt_url_codificada
                 width: flick2.width
                 height: flick2.height
                 focus: true
                 onCursorRectangleChanged: flick2.ensureVisible(cursorRectangle)
             }
         }
//        TextEdit {
//            anchors.fill: parent
//            id: txt_url_codificada
//            width: 346
//            height: 19
//            font.pointSize: 12
//            clip: true
//      }
    }
}
