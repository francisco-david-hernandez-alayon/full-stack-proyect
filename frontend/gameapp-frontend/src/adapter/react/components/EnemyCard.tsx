import type React from "react";
import type { Enemy } from "../../../domain/entities/enemy";

interface EnemyCardProps {
  enemy: Enemy;
}

export const EnemyCard: React.FC<EnemyCardProps> = ({ enemy }) => {
  return (
    <div className="card w-72 bg-custom-background shadow-md">
      <div className="card-body">
        <h2 className="card-title text-custom-secondary">{enemy.name.name}</h2>
        <p>HP: {enemy.healthPoints}</p>
        <p>Damage: {enemy.attackDamage}</p>
        <p>Speed: {enemy.speedAttack}</p>
      </div>
    </div>
  );
};