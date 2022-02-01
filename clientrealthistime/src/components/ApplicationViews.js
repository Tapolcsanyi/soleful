import React from "react";
import Login from "./Login";
import Register from "./Register";
import SneakerCard from "./sneaker/sneakerCard";
import SneakerList from "./sneaker/sneakerList";
import { Switch, Route, Redirect } from "react-router-dom";
import SneakerDetails from "./sneaker/sneakerDetails";
import firebase from "firebase";
import 'firebase/auth'; //v9
import 'firebase/firestore'; //v9

export default function ApplicationViews({ isLoggedIn }) {

  const user = firebase.auth().currentUser;

  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <SneakerList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/sneaker/:id">
          {isLoggedIn ? <SneakerDetails /> : <Redirect to="/login" />}
        </Route>

        <Route path="/login">
          <Login />
        </Route>

        <Route path="/register">
          <Register />
        </Route>
      </Switch>
    </main>
  );
};
