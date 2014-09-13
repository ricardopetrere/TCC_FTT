import QtQuick 2.0

Rectangle {
    width: 100
    height: 100
    color: "grey"
    Rectangle {
        width: 50
        height: 80
        color: "lightgrey"
        //z:1//0 é o padrão. Valor negativo coloca abaixo do elemento-pai
        //clip: true//proíbe os elementos-filho de exceder o elemento-pai (texto saindo do Rectangle)
        Text {
            text: "Sunday, 5 o'clock"
        }
    }
    Rectangle {
        width: 25
        height: 40
        color: "green"
        Text {
            anchors.verticalCenter: parent.verticalCenter
            text: "Tee time!"
        }
    }
}
