#include "mainwindow.h"
#include "./ui_mainwindow.h"
#include "QPushButton"
#include "QMessageBox"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::Display(){
    ShowMessageBox();
    this->show();
}

void MainWindow::ShowMessageBox(){
    QMessageBox msgBox;
    msgBox.setText("The document has been modified.");
    msgBox.exec();
}
