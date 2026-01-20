import { useNavigate } from "react-router-dom";
import type { AlertData } from "../App";
import { CreateNewGameButton } from "../components/Game/CreateNewGameButton";
import { BookOpen, FolderOpen } from "lucide-react";

interface HomePageProps {
  showAlert: (data: AlertData) => void;
}

export const HomePage: React.FC<HomePageProps> = ({ showAlert }) => {
    const navigate = useNavigate();

    const goToHowToPlay = async () => {
        navigate(`/how-to-play`)
    }

    const goToGames = async () => {
        navigate(`/games`)
    }

    return (
        <div className="flex flex-col items-center gap-16 p-8 max-w-3xl mx-auto">

            {/* Title */}
            <h1 className="text-4xl font-bold text-custom-primary-title text-center">
                Welcome to the Adventure
            </h1>

            {/* Game description */}
            <p className="text-center text-sm leading-relaxed max-w-xl">
                This is a turn-based adventure game where survival is your main objective.
                Progress through multiple scenes, explore different biomes, fight enemies,
                manage your inventory, and make strategic decisions to reach the final scene alive.
                Every choice matters, and preparation is the key to success.
            </p>

            {/* Main Actions */}
            <div className="flex flex-col sm:flex-row gap-4 items-center justify-center">

                <CreateNewGameButton showAlert={showAlert} />

                <button className="btn btn-secondary flex items-center gap-2" onClick={() => navigate("/games")} >
                    <FolderOpen className="w-4 h-4" />
                    Load Game
                </button>

                <button className="btn btn-terciary flex items-center gap-2" onClick={() => navigate("/how-to-play")} >
                    <BookOpen className="w-4 h-4" />
                    How to Play
                </button>

            </div>

        </div>
    );
};