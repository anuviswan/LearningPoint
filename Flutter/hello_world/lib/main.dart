import 'package:flutter/material.dart';

// Example 1: Simple Hello World
//void main() => runApp(
//    new Center(
//          child: new Text("This is a Hello World from Flutter",textDirection: TextDirection.rtl),
//              )
//    );


// Example 2: Stateless Hello World
void main()=>runApp(new myStatelessApplication());

class myStatelessApplication extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'My Stateless Hello World !',
      home: new Scaffold(
        body: new Container(
          color: Colors.blue,
          child: new Container(
            color: Colors.white,
            margin: EdgeInsets.all(30),
            child: new Center(
              child: new Text('This is hello world app',textDirection: TextDirection.ltr,),
            ),
          ),
        ),
      ),
    );
  }
}
