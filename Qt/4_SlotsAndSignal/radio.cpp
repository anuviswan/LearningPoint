#include "radio.h"

Radio::Radio(QObject *parent, QString name):QObject(parent)
{
    _name = name;
}

void Radio::OnBroadcastRecieved(QString message)
{
    qInfo() << "Recieved broadcast on" << _name << ":" <<message;
}
