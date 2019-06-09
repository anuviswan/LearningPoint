import 'package:flutter/material.dart';

void main() => runApp(myStatefulApplication());

class myStatefulApplication extends StatefulWidget {
  @override
  _myStatefulApplicationState createState() => _myStatefulApplicationState();
}

class _myStatefulApplicationState extends State<myStatefulApplication> {
  int count = 0;
  String titleText = '';

  @override
  void initState() {
    // TODO: implement initState
    titleText = 'Press this button';

    super.initState();
  }

  void OnPressMethod(){
    setState(() {
      count= count + 1;
      titleText = 'Button has been pressed  $count times';

    });
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'My Stateful Application',
      home: new Scaffold(
        appBar: new AppBar(title: new Text('My Stateful Application'),),
        body: new Center(
          child: new RaisedButton(onPressed: OnPressMethod,child: new Text(titleText),),
        )
      )
    );
  }
}
