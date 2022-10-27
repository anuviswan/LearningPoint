#ifndef CHANNEL_H
#define CHANNEL_H

#include <QObject>
#include <QDebug>

class Channel : public QObject
{
    Q_OBJECT
public:
    explicit Channel(QObject *parent = nullptr);
    void SendMessage(QString message);
    void RaiseQuit();

signals:
    void Broadcast(QString message);
    void Quit();

};

#endif // CHANNEL_H
