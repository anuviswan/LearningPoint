#include <QCoreApplication>
#include "source.h"
#include "destination.h"

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    Source sourceObj;
    Destination destinationObj;

    QObject::connect(&sourceObj,&Source::setMessage,&destinationObj,&Destination::OnMessageRecieved);

    sourceObj.TriggerEvent();

    return a.exec();
}
