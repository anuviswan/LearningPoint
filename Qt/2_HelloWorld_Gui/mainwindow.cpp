#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->pushButton->connect(ui->pushButton,&QPushButton::clicked,this,&MainWindow::OnButtonClick);
}



MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::OnButtonClick(bool isClicked)
{
    qInfo() << "Button Clicked : #" << isClicked;

    QMessageBox msgBox;
    msgBox.setText("Hey, button clicked");
    msgBox.exec();
}

