import React from 'react';
import Header from '../Header';
import './Home.css';
import Sidebar from './Sidebar';

function Home() {
    return (
        <div className="home">
            <Header />
            <div className="home_container">
            <Sidebar />
            {/*<Feed />*/}
            {/*<Right />*/}
            </div>
        </div>
    )
}

export default Home;