import 'package:flutter/material.dart';

void main() => runApp(datelistapplication());

class datelistapplication extends StatefulWidget {
  @override
  _datelistapplicationState createState() => _datelistapplicationState();
}

class _datelistapplicationState extends State<datelistapplication> {

  List<DateTime> listOfDates = new List();
  DateTime currentDateTime = new DateTime.now();

  @override
  void initState(){
    for(int i=0;i<10;i++){
      listOfDates.add(currentDateTime);
      currentDateTime.add(Duration(days:1));
    }

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return new MaterialApp(
      title: 'Date List Example',
      home: new Scaffold(
        appBar: new AppBar(title: new Text('Date List Application'),),
        body: new Center(

            ),
      ),
    );
  }
}
