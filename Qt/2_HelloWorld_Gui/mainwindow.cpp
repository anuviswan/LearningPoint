#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->pushButton->click();
}



MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::OnButtonClick()
{

}

