import type { AlertData } from "../App";
import { CreateNewGameButton } from "../components/Game/CreateNewGameButton";

interface HomePageProps {
  showAlert: (data: AlertData) => void;
}

export const HomePage: React.FC<HomePageProps> = ({ showAlert }) => {
    return (
        <>
            <div className="flex flex-col align-center p-6">
                <h1 className="text-custom-primary-title"> WELCOME! </h1>

                <div className="flex items-center justify-center">
                    <CreateNewGameButton showAlert={showAlert}/>
                </div>
                
            </div>
        </>
    );
};