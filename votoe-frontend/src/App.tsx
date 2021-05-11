import React from "react";
import "./App.scss";
import Home from "./components/Home/Home";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Dashboard from "./components/Dashboard/Dashboard";
import VoteHere from "./components/Vote/VoteHere";
import Profile from "./components/Profile/Profile";
import Registration from "./components/Registration/Registration";

function App() {

  return (
    <Router>
      <div className="app">
        <Switch>
          <Route path="/registration" component={Registration}></Route>

          <Route path="/profile" component={Profile}>
          {/* <Route path="/profile/:id" component={Profile}></Route> */}
          </Route>

          <Route path="/dashboard" exact component={Dashboard}></Route>

          <Route path="/vote" component={VoteHere}>
            <Route path="/vote/:voteID" component={VoteHere}></Route>
          </Route>

          <Route path="/" exact component={Home}></Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
