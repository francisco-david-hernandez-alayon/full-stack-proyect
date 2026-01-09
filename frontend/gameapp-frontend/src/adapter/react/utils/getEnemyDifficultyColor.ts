import { EnemyDifficulty } from "../../../domain/enumerates/enemy-difficulty";

export const getEnemyDifficultyColor = (difficulty: EnemyDifficulty): string => {
    switch (difficulty) {
        case EnemyDifficulty.Easy:
            return "text-[var(--color-easy-enemy)]";
        case EnemyDifficulty.Normal:
            return "text-[var(--color-normal-enemy)]";
        case EnemyDifficulty.Hard:
            return "text-[var(--color-hard-enemy)]";
        case EnemyDifficulty.Boss:
            return "text-[var(--color-boss-enemy)]";
        default:
            return "";
    }
};