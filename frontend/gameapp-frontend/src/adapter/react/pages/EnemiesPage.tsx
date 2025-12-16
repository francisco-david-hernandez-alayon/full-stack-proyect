import React, { useEffect, useState } from "react";
import { EnemyCard } from "../components/EnemyCard";
import type { Enemy } from "../../../domain/entities/enemy";
import { EnemyHttpRepository } from "../../http/repository/enemy-http-repository";

export const EnemiesPage: React.FC = () => {
  const [enemies, setEnemies] = useState<Enemy[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // Get all enemies when the component is mounted
  useEffect(() => {
    const repoEnemy = new EnemyHttpRepository();

    const fetchEnemies = async () => {
      try {
        const allEnemies = await repoEnemy.fetchAll();
        setEnemies(allEnemies);

      } catch (err) {
        setError("Error fetching enemies");

      } finally {
        setLoading(false);
      }
    };

    fetchEnemies();
  }, []);


  if (loading) {
    return <div className="p-6">Loading enemies...</div>;
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
