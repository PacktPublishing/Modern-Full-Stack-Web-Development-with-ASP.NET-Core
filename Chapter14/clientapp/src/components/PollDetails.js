import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Button, ListGroup } from 'react-bootstrap';

const PollDetails = () => {
  const { pollId } = useParams();
  const [poll, setPoll] = useState(null);
  const [selectedOption, setSelectedOption] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetch(`http://localhost:5261/api/polls/${pollId}`)
      .then(response => response.json())
      .then(data => setPoll(data))
      .catch(error => console.error('Error fetching poll:', error));
  }, [pollId]);

  const submitVote = () => {
    if (!selectedOption) {
      alert('Please select an option to vote.');
      return;
    }

    fetch(`http://localhost:5261/api/polls/${pollId}/vote`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ userId: 'user123', optionId: selectedOption })
    })
      .then(response => {
        if (response.ok) {
          navigate(`/poll/${pollId}/results`);
        } else {
          alert('Error submitting vote.');
        }
      })
      .catch(error => console.error('Error submitting vote:', error));
  };

  return poll ? (
    <div className="container">
      <h2>{poll.question}</h2>
      <ListGroup>
        {poll.options.map(option => (
          <ListGroup.Item
            key={option.id}
            action
            onClick={() => setSelectedOption(option.id)}
            active={selectedOption === option.id}
          >
            {option.text}
          </ListGroup.Item>
        ))}
      </ListGroup>
      <Button className="mt-3" variant="success" onClick={submitVote}>
        Submit Vote
      </Button>
    </div>
  ) : (
    <div>Loading...</div>
  );
};

export default PollDetails;
