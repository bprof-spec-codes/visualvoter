import axios from "../../axios";
import React, { useState, useEffect } from "react";
import "./Feed.css";
import VoteResult from "./VoteResult";

function Feed() {
  const [results, setResults] = useState([]);

  useEffect(() => {
    axios.get("/posts").then((response) => {
      const res=response.data;
      //console.log(res);
      setResults(res);
      console.log(results);
    }).catch(error=>{
        console.log(error.message);
    });
  }, []);

  return (
    <div className="feed">
      {results.map(item=>{
          return(
            <VoteResult
                key={item.id}
                title={item.title}
                body={item.body}
            />
          );
      })}
    </div>
  );
}

export default Feed;
