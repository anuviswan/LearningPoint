import QtQuick 2.15
import QtQuick.Window 2.15
import QtQuick.Controls 2.5;

Window {
    width: 640
    height: 480
    visible: true
    title: qsTr("Hello World - Qml Demo Application")

    Button {
        id : btnClickMe
        text : qsTr("Click Me !!")
        anchors.centerIn: parent
        height: 50
        width: 100
    }

}
