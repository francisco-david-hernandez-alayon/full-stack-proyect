import type React from "react";
import { Backpack, DollarSign, Gamepad, Ham, Heart, Trash2, User } from "lucide-react";
import { GameStatus } from "../../../../domain/enumerates/game-status";
import { Game } from "../../../../domain/entities/game";
import type { Scene } from "../../../../domain/entities/scenes/scene";
import { getStyleForBiome } from "../../utils/GetBiomeStyle";


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
    const biomeStyle = getStyleForBiome(scene.biome);

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
    onDeleteGame: () => void;
}

export const GameCardButtons: React.FC<GameCardButtonsProps> = ({ gameStatus, onContinue, onDeleteGame }) => {
    if (gameStatus !== GameStatus.GAME_IN_PROGRESS) return (
        <div className="mt-4 flex flex-col items-center gap-4">
            <button
                className="btn btn-secondary flex items-center gap-2 btn-sm w-36"
                onClick={onDeleteGame}
            >
                <Trash2 className="w-4 h-4" />
                Delete Game
            </button>
        </div>
    );

    return (
        <div className="mt-4 flex flex-col items-center gap-4">
            <button
                className="btn btn-primary btn-lg w-48"
                onClick={onContinue}
            >
                Continue Game
            </button>

            <button
                className="btn btn-secondary flex items-center gap-2 btn-sm w-36"
                onClick={onDeleteGame}
            >
                <Trash2 className="w-4 h-4" />
                Delete Game
            </button>
        </div>

    );
};


//----------------------------------------------------------------MAIN FUNCTION-------------------------------------------------------------------//

interface GameCardProps {
    game: Game;
    onContinueGame: () => void;
    onDeleteGame: () => void;
}

export const GameCard: React.FC<GameCardProps> = ({ game, onContinueGame, onDeleteGame }) => {
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
                    ({game.completedScenes.length} / {game.numberScenesToFinish} scenes)  {game.difficulty}
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

            {/* ACTIONS BUTTONS */}
            <GameCardButtons
                gameStatus={game.status}
                onContinue={onContinueGame}
                onDeleteGame={onDeleteGame}
            />


            {/* ID */}
            <div className="mt-4 text-center text-xs opacity-50">
                Game ID #{game.id}
            </div>
        </div>
    );
};
