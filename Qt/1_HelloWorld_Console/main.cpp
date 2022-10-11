#include <QCoreApplication>
#include <QtDebug>
#include <iostream>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    qInfo("Hello World Demo");

    QString name = argc == 2 ? argv[1] : "John Doe <Default Name>";

    qInfo("Hello World %s",qPrintable(name));
    return a.exec();
}
