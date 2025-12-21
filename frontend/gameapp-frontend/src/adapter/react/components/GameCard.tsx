import type React from "react";
import type { Game } from "../../../domain/entities/game";
import { Backpack, DollarSign, Gamepad, Ham, Heart, User } from "lucide-react";
import { GameStatus } from "../../../domain/enumerates/game-status";
import { Biome } from "../../../domain/enumerates/biome";
import type { Scene } from "../../../domain/entities/scenes/scene";
import { getBiomeStyle } from "../utils/GetBiomeStyle";

interface GameCardProps {
    game: Game;
    onContinueGame: () => void;
}

//------------------------------------------------------------------------UTILS---------------------------------------------------------------------------//
const getStatusLabel = (status: GameStatus): string => {
    switch (status) {
        case GameStatus.GAME_IN_PROGRESS:
            return "In Progress";
        case GameStatus.GAME_WON:
            return "Victory";
        case GameStatus.PLAYER_DEATH:
            return "Defeat";
        default:
            return "";
    }
};

const getStatusColorClass = (status: GameStatus): string => {
    switch (status) {
        case GameStatus.GAME_IN_PROGRESS:
            return "text-amber-500";
        case GameStatus.GAME_WON:
            return "text-green-600";
        case GameStatus.PLAYER_DEATH:
            return "text-red-600";
        default:
            return "text-primary";
    }
};

//-------------------------------------------------------REACT FUNCTIONS-------------------------------------------------------------//
const sceneInfo = (scene: Scene) => {
    const biomeStyle = getBiomeStyle[scene.biome];

    return (
        <div
            key={scene.id}
            className="flex items-center gap-3 p-3 rounded-lg shadow-sm"
            style={{ backgroundColor: biomeStyle.color }}
        >
            <img
                src={biomeStyle.image}
                alt={scene.biome}
                className="h-8 w-8 object-contain"
            />

            <div className="flex flex-col">
                <span className="text-sm font-medium text-custom-background">
                    {scene.name.name}
                </span>
                <span className="text-xs opacity-80 text-custom-background">
                    {scene.biome}
                </span>
            </div>
        </div>
    );
};

interface GameCardButtonsProps {
    gameStatus: GameStatus;
    onContinue: () => void;
}

export const GameCardButtons: React.FC<GameCardButtonsProps> = ({ gameStatus, onContinue }) => {
    if (gameStatus !== GameStatus.GAME_IN_PROGRESS) return null;

    return (
        <div className="mt-4 flex justify-center">
            <button className="btn btn-primary" onClick={onContinue}>
                Continue Game
            </button>
        </div>
    );
};


//----------------------------------------------------------------MAIN FUNCTION-------------------------------------------------------------------//
export const GameCard: React.FC<GameCardProps> = ({ game, onContinueGame }) => {
    const statusLabel = getStatusLabel(game.status);
    const statusColor = getStatusColorClass(game.status);

    return (
        <div className="card flex flex-column gap-3 shadow-md p-6 max-w-full bg-background">
            {/* Title */}
            <div className={`flex items-center justify-between font-semibold ${statusColor}`}>
                <div className="flex items-center gap-2">
                    <Gamepad className="w-5 h-5" />
                    <h2>
                        Game {statusLabel}
                    </h2>
                </div>

                <span className="text-sm opacity-70 font-normal">
                    ({game.completedScenes.length} / {game.numberScenesToFinish} scenes)
                </span>
            </div>

            {/* Current Scenes */}
            <div className="">


                <div
                    className={`grid gap-1 h-30 ${game.currentScenes.length === 1
                        ? "grid-cols-1"
                        : "grid-cols-1 md:grid-cols-2"
                        }`}
                >
                    {game.currentScenes.map(scene => sceneInfo(scene))}
                </div>
            </div>

            <div className="divider"></div>

            {/* Character info */}
            <div className="flex flex-col gap-3 text-sm text-custom-secondary">


                <div className="flex items-center justify-between">
                    <div className="flex items-center gap-2">
                        <User className="w-5 h-5" />
                        <span className="font-medium">
                            {game.character.name.name}
                        </span>
                    </div>

                    <div className="flex items-center gap-4 text-xs">
                        <div className="flex items-center gap-1">
                            <Heart className="w-4 h-4" />
                            <span>
                                {game.character.currentHealthPoints}/{game.character.maxHealthPoints}
                            </span>
                        </div>

                        <div className="flex items-center gap-1">
                            <Ham className="w-4 h-4" />
                            <span>
                                {game.character.currentFoodPoints}/{game.character.maxFoodPoints}
                            </span>
                        </div>

                        <div className="flex items-center gap-1">
                            <Backpack className="w-4 h-4" />
                            <span>
                                {game.character.inventoryList.length}/{game.character.maxInventorySlots}
                            </span>
                        </div>

                        <div className="flex items-center gap-1">
                            <DollarSign className="w-4 h-4" />
                            <span>
                                {game.character.currentMoney}
                            </span>
                        </div>
                    </div>
                </div>
            </div>

            {/* CONTINUE BUTTON */}
            <GameCardButtons
                gameStatus={game.status}
                onContinue={onContinueGame}
            />


            {/* ID */}
            <div className="mt-4 text-center text-xs opacity-50">
                Game ID #{game.id}
            </div>
        </div>
    );
};
