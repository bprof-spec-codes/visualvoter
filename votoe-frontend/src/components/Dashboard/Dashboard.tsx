import React from 'react';
import Header from '../Header';
import ActiveRequests from './ActiveRequests';
import CreateNewVote from './CreateNewVote';
import './Dashboard.scss';

function Dashboard() {
    return (
        <div className="dashboard">
            <Header />
            <div className="dashboard_container">
                {/*<Sidebar />*/}
                <ActiveRequests />
                <CreateNewVote />
                
                {/* Stats */}
            </div>
        </div>
    )
}

export default Dashboard;