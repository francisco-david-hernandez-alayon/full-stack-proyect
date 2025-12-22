import React, { useEffect, useState } from "react";
import type { Enemy } from "../../../domain/entities/enemy";
import { EnemyHttpRepository } from "../../http/repository/enemy-http-repository";
import type { AlertData } from "../App";
import { EnemyCard } from "../components/Cards/EnemyCard";
import { EnemyGetService } from "../../../application/services/enemy-services/enemy-get-service";
import { AlertTimeMessage, AlertType } from "../components/Structure/AlertMessage";

interface EnemiesPageProps {
  showAlert: (data: AlertData) => void;
}

export const EnemiesPage: React.FC<EnemiesPageProps> = ({ showAlert }) => {
  const [enemies, setEnemies] = useState<Enemy[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // Get all enemies when the component is mounted
  useEffect(() => {
    const repoEnemy = new EnemyHttpRepository();
    const enemyGetService = new EnemyGetService(repoEnemy);

    const fetchEnemies = async () => {
      try {
        const allEnemies = await enemyGetService.getAllEnemys();
        setEnemies(allEnemies);

      } catch (err) {
        showAlert({
          message: "Error fecthing enemies: " + error,
          type: AlertType.ERROR,
          duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
        });

      } finally {
        setLoading(false);
      }
    };

    fetchEnemies();
  }, []);


  if (loading) {
    return <div> <span className="loading loading-spinner loading-xs"></span> <div className="p-6">Loading enemies...</div></div>;
  }

  if (error) {
    return <div className="p-6 text-error">{error}</div>;
  }

  return (
    <div className="p-6">
      <h1 className="text-custom-primary-title">
        Enemies
      </h1>

      <div className="grid grid-cols-2 md:grid-cols-5 gap-4">
        {enemies.map((enemy) => (
          <EnemyCard key={enemy.id} enemy={enemy} />
        ))}
      </div>

    </div>
  );
};
