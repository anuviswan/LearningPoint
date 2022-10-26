#include "tiger.h"

Tiger::Tiger(QObject *parent)
    : Animal(parent)
{
    qInfo() << "Tiger Constructed";
}

Tiger::~Tiger()
{
    qInfo() << "Tiger Deconstructed";
}
