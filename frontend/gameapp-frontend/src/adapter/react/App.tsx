import { useState } from 'react';
import './App.css';
import './example';
import { Header } from './components/Header';
import { AppRouter } from "./router/AppRouter";


const App: React.FC = () => {
  const [count, setCount] = useState<number>(0);

  return (
    <>
      <Header />
      <AppRouter />
    </>
  );
};

export default App;
