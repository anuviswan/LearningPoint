#ifndef DESTINATION_H
#define DESTINATION_H

#include <QObject>
#include <QDebug>

class Destination : public QObject
{
    Q_OBJECT
public:
    explicit Destination(QObject *parent = nullptr);

public slots:
    void OnMessageRecieved(QString message);

signals:



};

#endif // DESTINATION_H
