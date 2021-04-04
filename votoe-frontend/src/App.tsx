import React, { useEffect } from "react";
import "./App.scss";
import Home from "./components/Home/Home";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
// import { useStateValue } from "./StateProvider";
import Dashboard from "./components/Dashboard/Dashboard";
import VoteHere from "./components/Vote/VoteHere";
import Login from "./components/Login/Login";

function App() {
  // const [{}, dispatch] = useStateValue();

  useEffect(() => {}, []);
  return (
    <Router>
      <div className="app">
        <Switch>
          <Route path="/dashboard" exact component={Dashboard}></Route>

          <Route path="/vote" component={VoteHere}>
            <Route path="/vote/:voteID" component={VoteHere}></Route>
          </Route>

          <Route path="/login" component={Login}></Route>

          <Route path="/" exact component={Home}></Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
