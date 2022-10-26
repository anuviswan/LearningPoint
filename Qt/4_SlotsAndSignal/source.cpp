#include "source.h"

Source::Source(QObject *parent)
    : QObject{parent}
{

}

void Source::TriggerEvent()
{
    QString message = "Say Hello !!!";
    qInfo() << "Emitting Signal with message "<<message;
    emit setMessage(message);
}
