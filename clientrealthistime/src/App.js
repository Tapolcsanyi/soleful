import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import { Spinner } from 'reactstrap';
import ApplicationViews from "./components/ApplicationViews";
import Header from './components/Header';
import UserSneakerList from './components/myCollection/myCollection';
import { onLoginStatusChange } from "./modules/authManager";
import './index.css'

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(null);

  useEffect(() => {
    onLoginStatusChange(setIsLoggedIn);
  }, []);

  if (isLoggedIn === null) {
    return <Spinner className="app-spinner dark" />;
  }

  return (
    <Router>
      <div className="appContainer">
      <Header isLoggedIn={isLoggedIn}/>
      <ApplicationViews isLoggedIn={isLoggedIn}/>
      </div>
    </Router>
  );
}

export default App;
