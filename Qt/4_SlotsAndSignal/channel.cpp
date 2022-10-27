#include "channel.h"

Channel::Channel(QObject *parent)
    : QObject{parent}
{

}

void Channel::SendMessage(QString message)
{
    qInfo() << "Broadcasting message from Channel : " << message;
    emit Broadcast(message);
}

void Channel::RaiseQuit()
{
    emit Quit();
}
