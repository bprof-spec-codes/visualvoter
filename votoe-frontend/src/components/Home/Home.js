import React from 'react';
import Header from '../Header';
import './Home.css';

function Home() {
    return (
        <div className="home">
            <Header />
            <h1>This is the Home component</h1>
            
            {/*<Sidebar />*/}
            {/*<Feed />*/}
            {/*<Right />*/}
        </div>
    )
}

export default Home;