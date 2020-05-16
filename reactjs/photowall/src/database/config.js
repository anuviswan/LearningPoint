import * as firebase from 'firebase'

var firebaseConfig = {
  apiKey: "AIzaSyDliVOVve2lSz9jYYUReLBDnVbfXhZhu5U",
  authDomain: "photowall-af8b9.firebaseapp.com",
  databaseURL: "https://photowall-af8b9.firebaseio.com",
  projectId: "photowall-af8b9",
  storageBucket: "photowall-af8b9.appspot.com",
  messagingSenderId: "375440982532",
  appId: "1:375440982532:web:d6beff1c987917835a6b51"

};

firebase.initializeApp(firebaseConfig)

const database = firebase.database

export { database }