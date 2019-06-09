import 'package:flutter/material.dart';

void main() => runApp(myStatefulApplication());

class myStatefulApplication extends StatefulWidget {
  @override
  _myStatefulApplicationState createState() => _myStatefulApplicationState();
}

class _myStatefulApplicationState extends State<myStatefulApplication> {
  String titleText = '';

  @override
  void initState() {
    // TODO: implement initState
    titleText = 'Press this button';
    super.initState();
  }

  void OnPressMethod(){
    setState(() {
      titleText = 'Button has been pressed';
    });
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'My Stateful Application',
      home: new Scaffold(
        body: new Center(
          child: new RaisedButton(onPressed: OnPressMethod,child: new Text(titleText),),
        )
      )
    );
  }
}
