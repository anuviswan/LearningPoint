#ifndef SOURCE_H
#define SOURCE_H

#include <QObject>
#include <QDebug>
class Source : public QObject
{
    Q_OBJECT
public:
    explicit Source(QObject *parent = nullptr);
    void TriggerEvent();

public slots:

signals:
    void setMessage(QString message);

};

#endif // SOURCE_H
