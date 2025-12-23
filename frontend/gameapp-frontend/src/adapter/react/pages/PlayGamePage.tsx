import { useEffect, useState } from "react";
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
import { GameUpdateService } from "../../../application/services/game-services/game-update-service";
import { GameGetService } from "../../../application/services/game-services/game-get-service";
import { GameStatus } from "../../../domain/enumerates/game-status";
import { InventorySlot } from "../components/Game/InventorySlot";
import { GameUseItemService } from "../../../application/services/game-services/game-use-item-service";


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
    const gameUseItemService = new GameUseItemService();


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


    //---------------------------------------------------------GAME-FUNCTIONS----------------------------------------------------------//
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

    const useItem = async (positionItemSelected: number) => {
        try {
            const updatedGame = await gameUseItemService.useItem(positionItemSelected, game);
            setGame(updatedGame);

        } catch (error) {
            showAlert({
                message: "Error using item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    }





    //----------------------------------------------------------------------------HTML-------------------------------------------------------------------------------//
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
            <div className="flex flex-row items-center justify-between p-6 bg-custom-background-soft rounded-xl">

                <div className="flex flex-row items-center gap-5 pl-10">
                    {game.character instanceof WarriorCharacter && (
                        <img
                            src={getStyleForCharacter(game.character).image}
                            alt="Warrior character"
                            className="h-20 w-20 rounded-full"
                        />
                    )}

                    <div className="flex flex-col gap-2 justify-center">
                        <h2 className="card-title text-custom-primary text-2xl">
                            {game.character.name.name}
                        </h2>

                        <div className="flex flex-row flex-wrap gap-5 text-custom-secondary">
                            <div className="flex items-center gap-1 text-lg">
                                <Heart className="w-8 h-8" />
                                <span>{game.character.currentHealthPoints}/{game.character.maxHealthPoints}</span>
                            </div>

                            <div className="flex items-center gap-1 text-lg">
                                <Ham className="w-8 h-8" />
                                <span>{game.character.currentFoodPoints}/{game.character.maxFoodPoints}</span>
                            </div>

                            <div className="flex items-center gap-1 text-lg">
                                <DollarSign className="w-8 h-8" />
                                <span>{game.character.currentMoney}</span>
                            </div>

                            <div className="flex items-center gap-1 text-lg">
                                <Sword className="w-8 h-8" />
                                <span>{game.character.attackDamage}</span>
                            </div>

                            <div className="flex items-center gap-1 text-lg">
                                <ActivityIcon className="w-8 h-8" />
                                <span>{game.character.attackSpeed}</span>
                            </div>
                        </div>

                    </div>
                </div>

                {/* Inventory */}
                <div className="flex items-center gap-5 pr-10">
                    {game.character.inventoryList.map((item, index) => (
                        <div key={index} className="flex flex-1 justify-center">
                            <InventorySlot item={item} useItem={() => (useItem(index))} />
                        </div>
                    ))}

                    {Array.from({
                        length: game.character.maxInventorySlots - game.character.inventoryList.length,
                    }).map((_, index) => (
                        <InventorySlot key={`empty-${index}`} useItem={() => (console.log("There's no item to use"))}  />
                    ))}

                    <Backpack className="w-20 h-20" />
                </div>
            </div>


        </div>
    );
};
