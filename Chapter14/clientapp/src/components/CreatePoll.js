import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom'; 

const CreatePoll = () => {
  const [question, setQuestion] = useState('');
  const [options, setOptions] = useState(['', '']);
  const [error, setError] = useState(null); 
  const navigate = useNavigate(); 

  const handleSubmit = async () => {

      if (!question || options.some(option => option.trim() === '')) {
      setError('Please fill in the question and all options.');
      return;
    }


    const newPoll = {
      question,
      options,
      expiresAt: new Date(Date.now() + 7 * 24 * 60 * 60 * 1000) 
    };

    try {
      const response = await fetch('http://localhost:5261/api/polls', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newPoll),
      });

      if (response.ok) {
        console.log('Poll created successfully');
        navigate('/polls');  
      } else {
        const errorData = await response.json();
        setError(`Failed to create poll: ${errorData.message}`);
      }
    } catch (err) {
      setError('Error connecting to the server. Please try again later.');
    }
  };

  const addOption = () => {
    setOptions([...options, '']);
  };

  return (
    <div className="container">
      <h2>Create a New Poll</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <Form>
        <Form.Group controlId="formQuestion">
          <Form.Label>Poll Question</Form.Label>
          <Form.Control
            type="text"
            placeholder="Enter poll question"
            value={question}
            onChange={(e) => setQuestion(e.target.value)}
          />
        </Form.Group>

        {options.map((option, index) => (
          <Form.Group key={index} controlId={`formOption${index}`}>
            <Form.Label>Option {index + 1}</Form.Label>
            <Form.Control
              type="text"
              placeholder={`Option ${index + 1}`}
              value={option}
              onChange={(e) => {
                const newOptions = [...options];
                newOptions[index] = e.target.value;
                setOptions(newOptions);
              }}
            />
          </Form.Group>
        ))}

        <Button variant="secondary" className="m-2" onClick={addOption}>
          Add Another Option
        </Button>

        <Button variant="primary" className="m-2" onClick={handleSubmit}>
          Create Poll
        </Button>
      </Form>
    </div>
  );
};

export default CreatePoll;
