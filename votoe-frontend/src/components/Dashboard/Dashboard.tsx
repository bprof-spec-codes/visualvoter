import React from 'react';
import Header from '../Header';
import CreateNewVote from './CreateNewVote';
import './Dashboard.scss';

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