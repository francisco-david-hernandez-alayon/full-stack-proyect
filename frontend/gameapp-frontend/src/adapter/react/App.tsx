import { useState } from 'react';
import './App.css';
import './example';
import { Header } from './components/Header';
import { AppRouter } from "./router/AppRouter";
import { AlertMessage, type AlertMessageProps, type AlertTimeMessage, type AlertType } from './components/AlertMessage';


export interface AlertData {
  message: string;
  type: AlertType;
  duration: AlertTimeMessage;
}


const App: React.FC = () => {
  const [alert, setAlert] = useState<AlertData | null>(null);

  const showAlert = (data: AlertData) => {
    setAlert(data);
  };

  return (
    <div className="flex flex-col h-screen">
      <Header />

      {/* Alerts */}
      <div className="absolute top-4 right-4 z-50">
        {alert && (
          <AlertMessage
            key={Date.now()} // force re-render if invoked consecutively
            message={alert.message}
            type={alert.type}
            duration={alert.duration}
          />
        )}
      </div>

      <div className="flex-1">
        <AppRouter showAlert={showAlert} />
      </div>
    </div>
  );
};

export default App;