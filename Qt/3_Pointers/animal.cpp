#include "animal.h"

Animal::Animal(QObject *parent)
    : QObject(parent)
{
    qInfo() << "Animal Constructed";
}

Animal::~Animal()
{
    qInfo() << "Animal Deconstructed";
}
