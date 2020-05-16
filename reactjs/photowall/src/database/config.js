import * as firebase from 'firebase'

var firebaseConfig = {
  // You configuration here
  // apiKey: 
  // authDomain: 
  // databaseURL: 
  // projectId:
  // storageBucket: 
  // messagingSenderId: 
  // appId: 
};

firebase.initializeApp(firebaseConfig)

const database = firebase.database

export { database }