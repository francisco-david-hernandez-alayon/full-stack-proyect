import { useEffect, useState } from "react";
import type { Game } from "../../../domain/entities/game";
import { GameHttpRepository } from "../../http/repository/game-http-repository";
import { GameCard } from "../components/GameCard";
import { useNavigate } from "react-router-dom";
import type { AlertData } from "../App";

interface GamePageProps {
  showAlert: (data: AlertData) => void;
}


export const GamesPage: React.FC<GamePageProps> = ({ showAlert }) => {
  const navigate = useNavigate();

  const [games, setGames] = useState<Game[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // Get all enemies when the component is mounted
  useEffect(() => {
    const repoGames = new GameHttpRepository();

    const fetchGames = async () => {
      try {
        let allGames: Game[] = [];
        allGames = await repoGames.fetchAll();
        setGames(allGames);

      } catch (err) {
        setError("Error fetching games");

      } finally {
        setLoading(false);
      }
    };

    fetchGames();
  }, []);


  return (
    <>
      <div className="p-6">
        <h1 className="text-custom-primary-title">Games</h1>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {games.map((game) => (
            <GameCard key={game.id} game={game} onContinueGame={() => navigate(`/play-game/${game.id}`)} />
          ))}
        </div>
      </div>
    </>
  );
};
