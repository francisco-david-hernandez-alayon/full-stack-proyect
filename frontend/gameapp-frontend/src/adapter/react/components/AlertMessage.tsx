import { useEffect, useState } from "react";

export enum AlertType {
  SUCCESS = "success",
  WARNING = "warning",
  ERROR = "error",
}

export enum AlertTimeMessage {
  SHORT_MESSAGE_DURATION = 2000,  // 2 seg
  MEDIUM_MESSAGE_DURATION = 4000, // 4 seg
  LONG_MESSAGE_DURATION = 6000,   // 6 seg
}

export interface AlertMessageProps {
  type: AlertType;
  duration: AlertTimeMessage;
  message: string;
}

export const AlertMessage: React.FC<AlertMessageProps> = ({ type, duration, message }) => {
  const [visible, setVisible] = useState(true);

  useEffect(() => {
    const timer = setTimeout(() => setVisible(false), duration);
    return () => clearTimeout(timer);
  }, [duration]);

  if (!visible) return null;

  const alertClass = {
    [AlertType.SUCCESS]: "alert-success",
    [AlertType.WARNING]: "alert-warning",
    [AlertType.ERROR]: "alert-error",
  }[type];

  return (
    <div className={`alert ${alertClass} shadow-lg my-2`}>
      <div className="flex justify-between items-center w-full">
        <span>{message}</span>
        <button className="btn btn-sm btn-ghost" onClick={() => setVisible(false)}>
          ✕
        </button>
      </div>
    </div>
  );
};
