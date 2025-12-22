import { Activity, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import type { Game } from "../../../domain/entities/game";
import { GameHttpRepository } from "../../http/repository/game-http-repository";
import type { AlertData } from "../App";
import { AlertTimeMessage, AlertType } from "../components/Structure/AlertMessage";
import { ActivityIcon, Backpack, DollarSign, Ham, Heart, Sword } from "lucide-react";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { getStyleForCharacter } from "../utils/GetCharacterStyle";
import { SceneCard } from "../components/Cards/SceneCard";
import { GameAdvanceSceneService } from "../../../application/services/game-services/game-advance-scene-service";
import { GameCreateService } from "../../../application/services/game-services/game-create-service";
import { GameUpdateService } from "../../../application/services/game-services/game-update-service";
import { GameGetService } from "../../../application/services/game-services/game-get-service";
import { GameStatus } from "../../../domain/enumerates/game-status";


interface PlayGamePageProps {
    showAlert: (data: AlertData) => void;

}


export const PlayGamePage: React.FC<PlayGamePageProps> = ({ showAlert }) => {
    const { id } = useParams<{ id: string }>(); // get url id
    const [game, setGame] = useState<Game | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    const repoGames = new GameHttpRepository();
    const gameGetService = new GameGetService(repoGames);
    const gameAdvanceSceneService = new GameAdvanceSceneService(repoGames);
    const gameUpdateService = new GameUpdateService(repoGames);


    useEffect(() => {
        if (!id) return;

        const fetchGame = async () => {
            try {
                const fetchedGame = await gameGetService.getGame(id);
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


    const moveForwardScene = async (sceneId: string) => {
        try {
            const updatedGame = await gameAdvanceSceneService.advance(sceneId, game);
            setGame(updatedGame);

            if (game.status == GameStatus.GAME_WON) {
            showAlert({
                message: "GAME WON",
                type: AlertType.SUCCESS,
                duration: AlertTimeMessage.MEDIUM_MESSAGE_DURATION,
            });  
            }

        } catch (error) {
            showAlert({
                message: "Error moving forward: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }

    }

    const saveGame = async () => {
        try {
            const updatedGame = await gameUpdateService.updateGame(game.id, game.character, game.numberScenesToFinish, game.finalScene, game.currentScenes, game.currentUserActions, game.completedScenes, game.status, game.currentEnemy);
            setGame(updatedGame);

            showAlert({
                message: "Game saved",
                type: AlertType.SUCCESS,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });

        } catch (error) {
            showAlert({
                message: "Error saving game: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    };


    return (
        <div className="flex flex-col h-full">
            {/* Header */}
            <div className="flex flex-row p-4 justify-between items-center h-20 bg-custom-secondary">
                <h1 className="text-custom-background">Game id ({game.id})</h1>

                <div className="flex flex-row items-center gap-12">
                    <button className="btn btn-custom-primary" onClick={() => saveGame()}>
                        Save game
                    </button>

                    <h1 className="text-custom-background">{game.completedScenes.length}/{game.numberScenesToFinish} scenes completed</h1>
                </div>

            </div>

            {/* Current Scenes */}
            <div className="flex flex-1  gap-12 p-12 bg-custom-background">
                {game.currentScenes.map((scene, index) => (
                    <div key={index} className="flex flex-1 justify-center">
                        <SceneCard scene={scene} getMoveForwardSceneId={moveForwardScene} canMoveForward={game.currentEnemy == null} />
                    </div>
                ))}
            </div>


            {/* Character info */}
            <div className="flex flex-row items-center gap-5 p-4 bg-custom-background-soft rounded-xl">
                {/* Character Image */}
                {game.character instanceof WarriorCharacter && (
                    <img
                        src={getStyleForCharacter(game.character).image}
                        alt="Warrior character"
                        className="h-20 w-20 rounded-full"
                    />
                )}

                {/* Name */}
                <div className="flex flex-col justify-center">
                    <h2 className="card-title text-custom-primary-title text-sm">
                        {game.character.name.name}
                    </h2>

                    {/* Stats in row */}
                    <div className="flex flex-row flex-wrap gap-5 mt-2 text-custom-secondary">
                        <div className="flex items-center gap-1 text-sm">
                            <Heart className="w-4 h-4" />
                            <span>{game.character.maxHealthPoints}</span>
                        </div>

                        <div className="flex items-center gap-1 text-sm">
                            <Ham className="w-4 h-4" />
                            <span>{game.character.maxFoodPoints}</span>
                        </div>

                        <div className="flex items-center gap-1 text-sm">
                            <DollarSign className="w-4 h-4" />
                            <span>{game.character.startingMoney}</span>
                        </div>

                        <div className="flex items-center gap-1 text-sm">
                            <Backpack className="w-4 h-4" />
                            <span>{game.character.maxInventorySlots}</span>
                        </div>

                        <div className="flex items-center gap-1 text-sm">
                            <Sword className="w-4 h-4" />
                            <span>{game.character.attackDamage}</span>
                        </div>

                        <div className="flex items-center gap-1 text-sm">
                            <ActivityIcon className="w-4 h-4" />
                            <span>{game.character.attackSpeed}</span>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    );
};
