import QtQuick 2.0
import QtQuick.Controls 1.1
import QtQuick.Controls.Styles 1.0

ApplicationWindow
{
    id: root
    width: 400
    height: 600
    visible:true
    title: qsTr("Conversas")

    //Referencial de tamanho para o cabeçalho do programa
    property int tamanho_cabecalho: 128

    //Barra de menu com as opções
    menuBar: MenuBar {
        Menu {
            id: conversas
            title: qsTr("Opções")
            MenuItem {
                text: qsTr("Logout")
                //Realizar logout. No momento só fecha a aplicação
                onTriggered: Qt.quit();
            }
        }
    }

    //Responsável por listar as conversas recentes
    ListView{
        anchors.fill: parent
        id:lista_conversas
        model: lista_conversas_model
        delegate: lista_conversas_delegate
    }

    //Model contendo as conversas recentes. No momento, os dados são estáticos.
    ListModel {
        id:lista_conversas_model
        //Conversa
        ListElement{
            caminho_imagem:"/images/ouster.png"
            nome_contato: "A"
            ultima_mensagem_contato:"Teste A"
        }
        //Conversa
        ListElement{
            caminho_imagem:"/images/qtcreator.png"
            nome_contato: "Qt Creator"
            ultima_mensagem_contato: "E aí? Tudo bem? Estou aqui te mandando essa mensagem porque eu preciso realizar um teste."
        }
    }

    //Delegate indicando o padrão do componente de "última conversa"
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
