import React, { useEffect } from "react";
import "./App.scss";
import Home from "./components/Home/Home";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
// import { useStateValue } from "./StateProvider";
import Dashboard from "./components/Dashboard/Dashboard";
import VoteHere from "./components/Vote/VoteHere";

function App() {
  // const [{}, dispatch] = useStateValue();

  useEffect(() => {}, []);
  return (
    <Router>
      <div className="app">
        <Switch>
          <Route path="/dashboard">
            <Dashboard />
          </Route>

          <Route path="/vote">
            <VoteHere { ...({} as any) }/>
          </Route>

          <Route path="/vote/:id">
            <VoteHere { ...({} as any) }/>
          </Route>

          <Route path="/">
            <Home />
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
