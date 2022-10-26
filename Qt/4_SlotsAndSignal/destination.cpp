#include "destination.h"

Destination::Destination(QObject *parent)
    : QObject{parent}
{

}

void Destination::OnMessageRecieved(QString message)
{
    qInfo() << "Recieved Message : " << message;
}
