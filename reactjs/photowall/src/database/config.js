import * as firebase from 'firebase'

var firebaseConfig = {
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