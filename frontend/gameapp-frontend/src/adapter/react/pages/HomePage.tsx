import type { AlertData } from "../App";
import { CreateNewGamePage } from "../components/Game/CreateNewGame";

interface HomePageProps {
  showAlert: (data: AlertData) => void;
}

export const HomePage: React.FC<HomePageProps> = ({ showAlert }) => {
    return (
        <>
            <div className="p-6">
                <h1 className="text-custom-primary-title">HOME</h1>

                <div className="flex items-center justify-center">
                    <CreateNewGamePage showAlert={showAlert}/>
                </div>
                
            </div>
        </>
    );
};