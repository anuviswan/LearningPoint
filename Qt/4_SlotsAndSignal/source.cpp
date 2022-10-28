#include "source.h"

QString Source::message()
{
    return _message;
}

void Source::setMessage(QString message)
{
    qInfo() << "Setting Property";
    _message = message;
    qInfo() << "Property Set";

    emit messageChanged(message);
}

Source::Source(QObject *parent)
    : QObject(parent)
{

}

void Source::TriggerEvent()
{
    QString message = "Say Hello !!!";
    qInfo() << "Emitting Signal with message "<<message;
    emit messageChanged(message);
}
