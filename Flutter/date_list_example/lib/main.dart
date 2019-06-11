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
      currentDateTime= currentDateTime.add(Duration(days:-1));
    }

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return new MaterialApp(
      title: 'Date List Example',
      home: new Scaffold(
        appBar: new AppBar(title: new Text('Last 10 Days'),),
        body: new Center(
          child: new ListView.builder(
            itemCount: listOfDates.length,
              itemBuilder: (BuildContext context,int index){
                var date = listOfDates[index];
              return new ListTile(
                title: new Text("${date.year.toString()}-${date.month.toString().padLeft(2,'0')}-${date.day.toString().padLeft(2,'0')}"),
                trailing: new Icon(Icons.date_range),
              );
              }),

            ),
      ),
    );
  }
}
