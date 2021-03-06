import React from 'react';
import Header from '../Header';
import Sidebar from '../Home/Sidebar';
import CreateNewVote from './CreateNewVote';
import './Dashboard.css';

function Dashboard() {
    return (
        <div className="dashboard">
            <Header />
            <div className="dashboard_container">
                {/*<Sidebar />*/}
                <CreateNewVote />
                {/* ActiveVotes */}
                {/* Stats */}
            </div>
        </div>
    )
}

export default Dashboard;