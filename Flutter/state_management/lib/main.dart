import 'package:flutter/material.dart';

void main() => runApp(MyApp());

class MyApp extends StatefulWidget {

  //MyApp({Key key}):super(key:key);

  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {

  int _currentValue = 0;

  @override
  void initState(){
    _currentValue =1;
    super.initState();
  }


  @override
  Widget build(BuildContext context) {
    return new MaterialApp(
      title: 'State Management Example',
      home: new Scaffold(
        appBar: new AppBar(title: new Text('State Management Example'),),
        body: new MainScreen(value: _currentValue,),
        floatingActionButton: new FloatingActionButton(onPressed: (){setState(() {
          _currentValue+=1;
        });}),
      ),
    );
  }
}

class MainScreen extends StatelessWidget {
  final int value;

  MainScreen({this.value});
  @override
  Widget build(BuildContext context) {
    return Center(
      child: new Text('Current Value is $value'),
    );
  }
}


