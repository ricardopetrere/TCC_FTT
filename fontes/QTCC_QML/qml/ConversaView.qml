import QtQuick 2.0

Rectangle{
    id:conversa
    property string caminho_imagem
    property string nome_contato
    property string ultima_mensagem_contato
    color: "white"
    //height: tamanho_cabecalho
    Image {
        id: foto_usuario
        //asynchronous: true
        source: caminho_imagem
        sourceSize.height: height

        //width: tamanho_cabecalho
        //height: width
        width: height
        anchors.bottom: parent.bottom
        anchors.top: parent.top
    }
    Rectangle{
        border.color: "brown"
        border.width: 100
        anchors.left: foto_usuario.right
        Text {
            id: txtnome_contato
            anchors.top: conversa.top
            anchors.left: parent.left
            font.bold: true
            text: nome_contato
        }
        Text {
            id: txtultima_mensagem_contato
            anchors.top: txtnome_contato.bottom
            anchors.left: parent.left
            text: ultima_mensagem_contato
        }
    }
    MouseArea {
        anchors.fill: parent
        onClicked: {
            console.log("Clicou")
        }
    }
}
