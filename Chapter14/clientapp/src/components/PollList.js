import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Button, Card } from 'react-bootstrap';

const PollList = () => {
  const [polls, setPolls] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5261/api/polls')
      .then(response => response.json())
      .then(data => setPolls(data))
      .catch(error => console.error('Error fetching polls:', error));
  }, []);

  return (
    <div className="container">
      <h2>Available Polls</h2>
      <div className="row">
        {polls.map(poll => (
          <div className="col-md-4 mb-3" key={poll.id}>
            <Card>
              <Card.Body>
                <Card.Title>{poll.question}</Card.Title>
                
                {/* Button to vote on the poll */}
                <Link to={`/poll/${poll.id}`}>
                  <Button variant="primary" className="m-2">Vote</Button>
                </Link>

                {/* Button to view poll results */}
                <Link to={`/poll/${poll.id}/results`}>
                  <Button variant="info" className="m-2">View Results</Button>
                </Link>
              </Card.Body>
            </Card>
          </div>
        ))}
      </div>
    </div>
  );
};

export default PollList;
