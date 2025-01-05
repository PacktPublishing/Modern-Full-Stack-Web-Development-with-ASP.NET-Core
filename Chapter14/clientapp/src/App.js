import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PollList from './components/PollList';
import PollDetails from './components/PollDetails';
import PollResults from './components/PollResults';
import Home from './components/Home'; 
import CreatePoll from './components/CreatePoll';



function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} /> {}
        <Route path="/polls" element={<PollList />} /> {}
        <Route path="/poll/:pollId" element={<PollDetails />} /> {}
        <Route path="/poll/:pollId/results" element={<PollResults />} /> {}
        <Route path="/create-poll" element={<CreatePoll />} /> {}
      </Routes>
    </Router>
  );
}

export default App;
