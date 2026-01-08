import type React from "react";
import { ActivityIcon, Bolt, DiamondPlusIcon, DollarSign, Heart, Sword,  } from "lucide-react";
import type { Enemy } from "../../../../domain/entities/enemy";

interface EnemyCardProps {
  enemy: Enemy;
}

export const EnemyCard: React.FC<EnemyCardProps> = ({ enemy }) => {
  return (
    <div className="card bg-background shadow-md p-3 max-w-xs">
      <h2 className="card-title text-primary mb-2">
        {enemy.name.name}
      </h2>

      <div className="flex flex-col gap-2 text-secondary">
        <div className="flex items-center gap-2">
          <Bolt className="w-5 h-5 text-custom-secondary" />
          <span>Difficulty: {enemy.difficulty}</span>
        </div>

        <div className="flex items-center gap-2">
          <Heart className="w-5 h-5 text-custom-secondary" />
          <span>HP: {enemy.healthPoints}</span>
        </div>

        <div className="flex items-center gap-2">
          <Sword className="w-5 h-5 text-custom-secondary" />
          <span>Damage: {enemy.attackDamage}</span>
        </div>

        <div className="flex items-center gap-2">
          <ActivityIcon className="w-5 h-5 text-custom-secondary" />
          <span>Speed: {enemy.speedAttack}</span>
        </div>

        <div className="flex items-center gap-2">
          <DiamondPlusIcon className="w-5 h-5 text-custom-secondary" />
          <span>{enemy.criticalDamage.criticalProbability}% of {enemy.criticalDamage.extraDamage} extra damage</span>
        </div>

        <div className="flex items-center gap-2">
          <DollarSign className="w-5 h-5 text-custom-secondary" />
          <span>Reward Money: {enemy.speedAttack}</span>
        </div>
      </div>
    </div>
  );
};