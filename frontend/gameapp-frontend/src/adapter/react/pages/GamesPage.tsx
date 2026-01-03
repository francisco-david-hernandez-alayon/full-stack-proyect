import { useEffect, useState } from "react";
import type { Game } from "../../../domain/entities/game";
import { GameHttpRepository } from "../../http/repository/game-http-repository";
import { useNavigate } from "react-router-dom";
import type { AlertData } from "../App";
import { GameCard } from "../components/Cards/GameCard";
import { CreateNewGameButton } from "../components/Game/CreateNewGameButton";
import { GameGetService } from "../../../application/services/game-services/game-get-service";
import { AlertTimeMessage, AlertType } from "../components/Structure/AlertMessage";
import { GameDeleteService } from "../../../application/services/game-services/game-delete-service";

interface GamePageProps {
  showAlert: (data: AlertData) => void;
}



export const GamesPage: React.FC<GamePageProps> = ({ showAlert }) => {
  const navigate = useNavigate();
  const repoGames = new GameHttpRepository();
  const gamesGetService = new GameGetService(repoGames);
  const gamesDeleteService = new GameDeleteService(repoGames);

  const [games, setGames] = useState<Game[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);


  const deleteGame = async (idGameToDelete: string) => {
    try {
      const deleteGame = await gamesDeleteService.deleteGame(idGameToDelete);
      showAlert({
        message: "game '" + deleteGame.id + "' deleted: ",
        type: AlertType.SUCCESS,
        duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
      });

    } catch (err) {
      showAlert({
        message: "Error deleting game '" + idGameToDelete + "': " + error,
        type: AlertType.ERROR,
        duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
      });

    }
  }

  // Get all enemies when the component is mounted
  useEffect(() => {

    const fetchGames = async () => {
      try {
        let allGames: Game[] = [];
        allGames = await gamesGetService.getAllGames();
        setGames(allGames);

      } catch (err) {
        showAlert({
          message: "Error fecthing games: " + error,
          type: AlertType.ERROR,
          duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
        });

      } finally {
        setLoading(false);
      }
    };

    fetchGames();
  }, [deleteGame]);

  


  return (
    <>
      <div className="flex flex-col align-center p-6">
        <h1 className="text-custom-primary-title">Games</h1>

        <div className="grid grid-cols-2 md:grid-cols-4 gap-4">
          {games.map((game) => (
            <GameCard key={game.id} game={game} onContinueGame={() => navigate(`/play-game/${game.id}`)} onDeleteGame={() => deleteGame(game.id)} />
          ))}
        </div>

        <div className="flex items-center justify-center p-5">
          <CreateNewGameButton showAlert={showAlert} />
        </div>
      </div>
    </>
  );
};
