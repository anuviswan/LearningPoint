#include <QCoreApplication>
#include <QDebug>
#include "tiger.h"

// Refreshing Pointers

void Print(QString* data){
    qDebug() <<"Value at #"
            <<data
            << "is "
            <<*data
            << "(Size:"
            << data->length()
            << ")"
            << "; Pointed by #"
            <<&data;
}

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    QString name = "John Doe";
    QString* designation = new QString("Senior Manager");

    qDebug() << "Printing value at " << &name;
    Print(&name);

    qDebug() << "Printing value at " << designation;
    Print(designation);

    Tiger *tiger = new Tiger(&a);

    delete tiger;
    return a.exec();
}
