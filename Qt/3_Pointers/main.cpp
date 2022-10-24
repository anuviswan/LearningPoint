#include <QCoreApplication>
#include <QDebug>


void Print(QString* data){
    qDebug() <<"Value at #"<<data << "is " <<*data << "; Pointed by #" <<&data;
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

    return a.exec();
}
