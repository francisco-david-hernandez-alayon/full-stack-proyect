import type React from "react";
import { Bug } from "lucide-react";
import type { Enemy } from "../../../../domain/entities/enemy";
import { getEnemyDifficultyColor } from "../../utils/getEnemyDifficultyColor";



interface RenderEnemyIconProps {
    enemy: Enemy;
    width: number;
    height: number;
}

export const RenderEnemyIcon: React.FC<RenderEnemyIconProps> = ({
    enemy,
    width,
    height,
}) => {
    const colorClass = getEnemyDifficultyColor(enemy.difficulty);


    return (
        <Bug
            className={colorClass}
            width={width}
            height={height}
        />
    );
};
