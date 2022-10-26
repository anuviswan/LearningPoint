#ifndef TIGER_H
#define TIGER_H

#include "animal.h"
#include <QObject>

class Tiger : public Animal
{
public:
    explicit Tiger(QObject *parent = nullptr);

    ~Tiger();
};

#endif // TIGER_H
