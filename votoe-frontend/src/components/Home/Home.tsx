import React from 'react';
import Header from '../Header';
import Feed from './Feed';
import './Home.scss';
import Right from './Right.';
import Sidebar from './Sidebar';

function Home() {

    return (
        <div className="home">
            <Header />
            <div className="home_container">
            <Sidebar />
            <Feed />
            <Right />
            </div>
        </div>
    )
}

export default Home;