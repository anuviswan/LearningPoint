#ifndef RADIO_H
#define RADIO_H

#include <QObject>
#include <QDebug>

class Radio : public QObject
{
    Q_OBJECT
    QString _name;
public:
    explicit Radio(QObject *parent = nullptr,QString name = "");

signals:

public slots:
    void OnBroadcastRecieved(QString message);

};

#endif // RADIO_H
