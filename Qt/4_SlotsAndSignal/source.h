#ifndef SOURCE_H
#define SOURCE_H

#include <QObject>
#include <QDebug>
class Source : public QObject
{
    Q_OBJECT
    QString _message;

    QString Message();
    void setMessage(QString message);

public:
    explicit Source(QObject *parent = nullptr);
    void TriggerEvent();

    Q_PROPERTY(QString message READ Message WRITE setMessage NOTIFY messageChanged)
public slots:

signals:
    void messageChanged(QString message);

};

#endif // SOURCE_H
