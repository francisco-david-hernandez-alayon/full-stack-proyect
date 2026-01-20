import type React from "react";
import { Angry } from "lucide-react";
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
        <Angry
            className={colorClass}
            width={width}
            height={height}
        />
    );
};
