import React, { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';
import { useParams } from 'react-router-dom';
import { Card, ListGroup, ProgressBar, Container } from 'react-bootstrap';

const PollResults = () => {
  const { pollId } = useParams();  
  const [options, setOptions] = useState([]);


  useEffect(() => {
    if (!pollId) return;  

    const fetchInitialResults = async () => {
      try {
        const response = await fetch(`http://localhost:5261/api/polls/${pollId}/results`);
        if (response.ok) {
          const data = await response.json();
          setOptions(data);  
        } else {
          console.error('Failed to fetch initial poll results.');
        }
      } catch (error) {
        console.error('Error fetching poll results:', error);
      }
    };

    fetchInitialResults();

    
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5261/voteHub")
      .configureLogging(signalR.LogLevel.Information)
      .build();

    connection.start()
      .then(() => {
        console.log('Connected to the SignalR hub');
        
       
        connection.on("ReceiveVoteUpdate", (updatedPollId, updatedOptions) => {
          if (updatedPollId === parseInt(pollId)) {
            setOptions(updatedOptions);  
          }
        });
      })
      .catch(err => console.error('Error connecting to SignalR hub:', err));

    return () => {
     
      connection.stop();
    };
  }, [pollId]);

  return (
    <Container className="mt-4">
      <h2 className="mb-4">Poll Results</h2>
      <Card>
        <Card.Body>
          <ListGroup>
            {options.map(option => (
              <ListGroup.Item key={option.id}>
                <div className="d-flex justify-content-between">
                  <span>{option.text}</span>
                  <span>{option.votes} votes</span>
                </div>
                <ProgressBar 
                  now={(option.votes / Math.max(...options.map(o => o.votes))) * 100} 
                  label={`${option.votes}`} 
                />
              </ListGroup.Item>
            ))}
          </ListGroup>
        </Card.Body>
      </Card>
    </Container>
  );
};

export default PollResults;
