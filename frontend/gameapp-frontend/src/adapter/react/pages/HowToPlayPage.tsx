import type { AlertData } from "../App";

interface HowToplayPageProps {
  showAlert: (data: AlertData) => void;
}


export const HowToPlayPage: React.FC<HowToplayPageProps> = ({ showAlert }) => {

    return (
        <div className="flex flex-col align-center p-6">
            <h1 className="text-custom-primary-title">How to play</h1>

        </div>
    );
};
