#include <QCoreApplication>
#include <QtDebug>
#include <iostream>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    std::cout << "Hello World using std:out" << std::flush;  // Print using std library
    qInfo() << "Hello World Demo";   // Print using Qt

    QString name = argc == 2 ? argv[1] : "John Doe";

    qInfo() << "Hello World" << qPrintable(name);
    return a.exec();
}
