import { Skull, Trophy } from "lucide-react";
import { GameStatus } from "../../../../domain/enumerates/game-status";
import type { Game } from "../../../../domain/entities/game";

interface GameSummaryProps {
  game: Game;
}

export const GameSummary: React.FC<GameSummaryProps> = ({ game }) => {
  const isVictory = game.status === GameStatus.GAME_WON;
  const isDefeat = game.status === GameStatus.PLAYER_DEATH;

  if (!isVictory && !isDefeat) return null;

  const bgColor = isVictory ? "bg-green-500" : "bg-red-500";
  const icon = isVictory ? <Trophy className="w-12 h-12 text-custom-background" /> : <Skull className="w-12 h-12 text-custom-background" />;

  return (
    <div className={`flex flex-col items-center justify-center h-full ${bgColor} p-6 rounded-xl gap-4`}>
      <div className="flex flex-col items-center gap-2">
        {icon}
        <h1 className="text-3xl font-bold text-custom-background">
          {isVictory ? "Victory!" : "Defeat"}
        </h1>
      </div>

      <div className="flex flex-col items-center gap-1 text-custom-background text-center">
        <span className="text-xl font-semibold">{game.character.name.name}</span>
        <span>HP: {game.character.currentHealthPoints}/{game.character.maxHealthPoints}</span>
        <span>Food: {game.character.currentFoodPoints}/{game.character.maxFoodPoints}</span>
        <span>Scenes Completed: {game.completedScenes.length}/{game.numberScenesToFinish}</span>
      </div>
    </div>
  );
};