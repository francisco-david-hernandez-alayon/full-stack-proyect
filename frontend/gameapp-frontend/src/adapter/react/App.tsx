import { useState } from 'react';
import './App.css';
import './example';
import { Header } from './components/Header';

const App: React.FC = () => {
  const [count, setCount] = useState<number>(0);

  return (
    <>
      <Header />
    </>
  );
};

export default App;
