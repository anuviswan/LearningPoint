#include <QCoreApplication>
#include <QDebug>
#include<QVariant>

#include "source.h"
#include "destination.h"
#include "channel.h"
#include "radio.h"



// a simple demonstration of Signals & slots
void SimpleDemo(QCoreApplication* app)
{
    Source sourceObj(app);
    Destination destinationObj(app);

    QObject::connect(&sourceObj,&Source::messageChanged,&destinationObj,&Destination::OnMessageRecieved);

    sourceObj.TriggerEvent();
}

void QPropertyDemo(QCoreApplication* app)
{
    Source sourceObj(app);
    Destination destinationObj(app);

    QObject::connect(&sourceObj,&Source::messageChanged,&destinationObj,&Destination::OnMessageRecieved);


    sourceObj.setProperty("message",  "HelloWorld");
    //sourceObj.TriggerEvent();
}

void RadioDemo(QCoreApplication *app)
{
    Channel channel(app);
    Radio* radio[3];

    radio[0] = new Radio(app, "John's Radio");
    radio[1] = new Radio(app, "Pauls's Radio");
    radio[2] = new Radio(app, "Smith's Radio");

    QObject::connect(&channel, &Channel::Quit, app, &QCoreApplication::quit);

    do{
        QTextStream qIn(stdin);
        QStringList input = qIn.readLine().split(" ");

        QString command = input[0].toUpper();

        qInfo() << "Recieved Command : " << command;

        if(command == "ON")
        {
            int radioId = input[1].toInt();

            qInfo() << "Turning On Radio #" << radioId;
            QObject::connect(&channel, &Channel::Broadcast, radio[radioId], &Radio::OnBroadcastRecieved);
            qInfo() << "Radio #" << radioId << "is switched on and connected";
            continue;

        }

        else if(command == "OFF")
        {
            int radioId = input[1].toInt();

            qInfo() << "Turning Off Radio #" << radioId;
            QObject::disconnect(&channel, &Channel::Broadcast, radio[radioId], &Radio::OnBroadcastRecieved);
            qInfo() << "Radio #" <<radioId << "has been turned off";
            continue;

        }

        else if(command == "SEND")
        {
            QString message = input[1];

            qInfo() << "Channel is ready to broadcast message : " << message;
            channel.SendMessage(message);
            qInfo() << "Channel has completed broadcast of message";
            continue;
        }

        else if(command == "QUIT")
        {
            qInfo() << "Quitting Application......";
            channel.RaiseQuit();
            return;
        }

        else
        {
            qInfo() <<"Invalid Command, exiting application";
            return;
        }
    }while(true);

}


int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    // SimpleDemo(&a);
    // RadioDemo(&a);
    QPropertyDemo(&a);
    return a.exec();
}

