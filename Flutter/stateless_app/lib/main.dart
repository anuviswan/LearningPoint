import 'package:flutter/material.dart';

void main() => runApp(myStatelessApplication());

class myStatelessApplication extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'My Stateless Hello World !',
      home: new Container(
        color: Colors.blue,
        child: new Container(
          color: Colors.white,
          margin: EdgeInsets.all(30),
          child: new Center(
            child: new Text('This is hello world app',textDirection: TextDirection.ltr,),
          ),
        ),
      ),
    );
  }
}
