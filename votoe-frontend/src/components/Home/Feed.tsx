import axios from "../../axios";
import React, { useState, useEffect } from "react";
import "./Feed.scss";
import VoteResult from "./VoteResult";

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
  const [results, setResults] = useState<IResult[]>([] as IResult[]);

  useEffect(() => {
    axios
      .get("/allvotes")
      .then((response) => {
        const res = response.data;
        //console.log(res);
        setResults(res);
        // console.log(results);
      })
      .catch((error) => {
        // console.log(error.message);
      });
  }, []);

  return (
    <div className="feed">
      {results.map((item) => {
        return (
          <VoteResult
            key={item.voteID}
            title={item.voteName}
            yesVotes={item.yesVotes}
            noVotes={item.noVotes}
            absentionVotes={item.absentionVotes}
            isClosed={item.isClosed}
            isFinished={item.isFinished}
          />
        );
      })}
    </div>
  );
}

export default Feed;
