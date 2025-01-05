import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';

const Home = () => {
  return (
    <div className="container text-center">
      <h1>Welcome to the Online Polling System</h1>
      <p>Select an option below to get started:</p>
      
      <Link to="/polls">
        <Button variant="primary" className="m-2">View All Polls</Button>
      </Link>

      <Link to="/create-poll">
        <Button variant="success" className="m-2">Create a New Poll</Button>
      </Link>
    </div>
  );
};

export default Home;
