import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import type { Game } from "../../../domain/entities/game";
import { GameHttpRepository } from "../../http/repository/game-http-repository";

export const PlayGamePage: React.FC = () => {
    const { id } = useParams<{ id: string }>(); // obtiene el id de la URL
    const [game, setGame] = useState<Game | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        if (!id) return;

        const repoGames = new GameHttpRepository();

        const fetchGame = async () => {
            try {
                const fetchedGame = await repoGames.fetchById(id);
                setGame(fetchedGame);
            } catch (err) {
                setError(`Error fetching game with id ${id}`);
            } finally {
                setLoading(false);
            }
        };

        fetchGame();
    }, [id]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p className="text-custom-error">{error}</p>;
    if (!game) return <p>Game not found</p>;

    return (
        <div className="p-6">
            <h1 className="text-custom-primary-title">Game {game.id}</h1>

            
        </div>
    );
};
