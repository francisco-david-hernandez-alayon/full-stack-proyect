import { useNavigate } from "react-router-dom";
import type { AlertData } from "../../App";

interface CreateNewGameProps {
    showAlert: (data: AlertData) => void;
}


export const CreateNewGameButton: React.FC<CreateNewGameProps> = ({ showAlert }) => {
    const navigate = useNavigate();

    const goToCreateNewGame = async () => {
        navigate(`/create-game`)
    }

    return (
        <>
            <button className="btn btn-primary" onClick={() => goToCreateNewGame()}>
                Start new Game
            </button>
        </>
    );
};