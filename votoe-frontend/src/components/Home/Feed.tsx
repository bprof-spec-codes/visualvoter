import axios from "../../axios";
import React, { useState, useEffect, useRef, useCallback } from "react";
import "./Feed.scss";
import VoteResult from "./VoteResult";

import AddIcon from "@material-ui/icons/Add";
import SearchIcon from "@material-ui/icons/Search";
import BrokenImageOutlinedIcon from "@material-ui/icons/BrokenImageOutlined";

interface IResult {
  voteID: string;
  voteName: string;
  yesVotes: number;
  noVotes: number;
  absentionVotes: number;
  isClosed: number;
  isFinished: number;
}

function Feed() {
  const [results, setResults] = useState([] as IResult[]);
  const [term, setTerm] = useState("");

  useEffect(() => {
    axios
      .get("/allvotes")
      .then((response) => {
        const res = response.data;
        setResults(res);
      })
      .catch((error) => {
        console.log(error.message);
      });
  }, []);

  useEffect(() => {
    renderResults();
  },[term])

  const handleChange = (e: any) => {
    e.preventDefault();

    setTerm(e.target.value);
  };

  const renderResults=()=>{
    const resVotes=results.filter(r=>r.voteName.toUpperCase()===term.toUpperCase())

    return(
      <>
      {results ?
      resVotes.length > 0 ? (resVotes.map(item=>(
        <VoteResult
        key={item.voteID}
        title={item.voteName}
        yesVotes={item.yesVotes}
        noVotes={item.noVotes}
        absentionVotes={item.absentionVotes}
        isClosed={item.isClosed}
        isFinished={item.isFinished}
      />
      ))) : (
        results.map((item)=>(
          <VoteResult
          key={item.voteID}
          title={item.voteName}
          yesVotes={item.yesVotes}
          noVotes={item.noVotes}
          absentionVotes={item.absentionVotes}
          isClosed={item.isClosed}
          isFinished={item.isFinished}
          />
        ))
      )
       : (
        <div className="feed_noVote">
          <p>Jelenleg nem található egyetlen szavazás sem</p>
        </div>
      )}
      </>
    );
  }

  return (
    <div className="feed">
      <div className="feed_top">
        <div className="feed_topContainer">
          <div className="feed_input">
            <SearchIcon style={{ color: "gray" }} />
            <input
              placeholder="Találj meg egy szavazást"
              onChange={handleChange}
              type="text"
            />
          </div>
        </div>
      </div>
      {renderResults()}
    </div>
  );
}

export default Feed;
