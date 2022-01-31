import React from "react";
import Login from "./Login";
import Register from "./Register";
import SneakerCard from "./sneaker/sneakerCard";
import SneakerList from "./sneaker/sneakerList";
import { Switch, Route, Redirect } from "react-router-dom";

export default function ApplicationViews({ isLoggedIn }) {

  return (
    <main>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <SneakerList /> : <Redirect to="/login" />}
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
