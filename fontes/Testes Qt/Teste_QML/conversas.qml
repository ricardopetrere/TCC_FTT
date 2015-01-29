import QtQuick 2.0
import QtQuick.Controls 1.1

ApplicationWindow
{
    id: root
    width: 400
    height: 600
    visible:true
    title: qsTr("Conversas")

    property int tamanho_cabecalho: 128

    menuBar: MenuBar {

        Menu {
            id: conversas
            title: qsTr("Options")
            MenuItem {
                text: qsTr("Logout")
                onTriggered: Qt.quit();
            }
        }
    }

    ListView{
        anchors.fill: parent
        id:lista_conversas
        model: lista_conversas_model
        delegate: lista_conversas_delegate
    }
    ListModel {
        id:lista_conversas_model
        ListElement{
            caminho_imagem:"images/images/ouster.png"
            nome_contato: "A"
            ultima_mensagem_contato:"Teste A"
        }
        ListElement{
            caminho_imagem:"/images/images/qtcreator.png"
            nome_contato: "Qt Creator"
            ultima_mensagem_contato: "E aí? Tudo bem? Estou aqui te mandando essa mensagem porque eu preciso realizar um teste."
        }
    }
    Component {
        id:lista_conversas_delegate
        Row{
            id:conversa
            height: tamanho_cabecalho
            Image {
                id: foto_usuario
                source: model.caminho_imagem
                width: tamanho_cabecalho
                height: tamanho_cabecalho
                anchors.bottom: parent.bottom
                anchors.top: parent.top
            }
            Rectangle{
                border.color: "brown"
                border.width: 10
                anchors.left: foto_usuario.right
                Text {
                    anchors.top: conversa.top
                    anchors.left: parent.left
                    id: txtnome_contato
                    font.bold: true
                    text: model.nome_contato
                }
                Text {
                    anchors.top: txtnome_contato.bottom
                    anchors.left: parent.left
                    id: txtultima_mensagem_contato
                    text: model.ultima_mensagem_contato
                }
            }
            spacing: 10
        }
    }
}
