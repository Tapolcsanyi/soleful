import React from "react";
import Login from "./Login";
import Register from "./Register";
import SneakerCard from "./sneaker/sneakerCard";
import SneakerList from "./sneaker/sneakerList";
import { UserSneakerList } from "./myCollection/myCollection";
import { Switch, Route, Redirect } from "react-router-dom";
import SneakerDetails from "./sneaker/sneakerDetails";
import firebase from "firebase";
import 'firebase/auth'; //v9
import 'firebase/firestore'; //v9
import { CollectionList } from "./list/collectionList";
import { CollectionDetails } from "./list/collectionDetails";
import { ListForm } from "./list/listForm";
import { ListUpdateForm } from "./list/listEditForm";
import { SneakerForm } from "./sneaker/sneakerForm";
import { SneakerUpdateForm } from "./sneaker/sneakerEditForm";

export default function ApplicationViews({ isLoggedIn }) {

  const user = firebase.auth().currentUser;

  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <SneakerList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/mycollection" exact>
          {isLoggedIn ? <UserSneakerList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/sneaker/:id">
          {isLoggedIn ? <SneakerDetails /> : <Redirect to="/login" />}
        </Route>

        <Route path="/sneakereditform/:id">
          {isLoggedIn ? <SneakerUpdateForm /> : <Redirect to="/login" />}
        </Route>

        <Route path="/createsneaker/">
          {isLoggedIn ? <SneakerForm /> : <Redirect to="/login" />}
        </Route>

        <Route path="/lists" exact>
          {isLoggedIn ? <CollectionList /> : <Redirect to="/login" />}
        </Route>

        <Route path="/lists/:id" exact>
          {isLoggedIn ? <CollectionDetails /> : <Redirect to="/login" />}
        </Route>

        <Route path="/listform" exact>
          {isLoggedIn ? <ListForm /> : <Redirect to="/login" />}
        </Route>

        <Route path="/listeditform/:id" exact>
          {isLoggedIn ? <ListUpdateForm /> : <Redirect to="/login" />}
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
