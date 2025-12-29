import type React from "react";
import type { Biome } from "../../../../domain/enumerates/biome";
import { SceneType } from "../../../../application/enumerates/scene-type";
import { getStyleForScene, getStyleForSceneType } from "../../utils/GetSceneStyle";

interface BiomeCardProps {
    biome: Biome;
    description: string;
    sceneProbabilities: Record<SceneType, number>;

    color?: string;
    image?: string;

}

export const BiomeCard: React.FC<BiomeCardProps> = ({ biome, description, sceneProbabilities, color, image }) => {
    return (
        <div
            className="card shadow-md p-8 max-w-full flex flex-col gap-2 items-center bg-background"
            style={{ backgroundColor: color }}
        >
            {image && (
                <img
                    src={image}
                    alt={biome}
                    className="w-32 h-32 object-contain mb-4"
                />
            )}

            <h2 className="card-title text-custom-background text-center mb-2">
                {biome}
            </h2>

            <p className="text-custom-background text-center">
                {description}
            </p>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-2 p-3">
                {Object.entries(sceneProbabilities)
                    .filter(([sceneType]) => sceneType !== SceneType.None)
                    .map(([sceneType, probability]) => {
                        const style = getStyleForSceneType(sceneType as SceneType);

                        return (
                            <div
                                key={sceneType}
                                className="flex items-center justify-between bg-black/20 rounded-lg w-70 p-5"
                            >
                                <div className="flex items-center gap-2">
                                    {style.image && (
                                        <img
                                            src={style.image}
                                            alt={sceneType}
                                            className="w-5 h-5"
                                        />
                                    )}
                                    <span className="text-custom-background text-sm">
                                        {style.name} Scene
                                    </span>
                                </div>

                                <span className="text-custom-background font-semibold">
                                    {probability}%
                                </span>
                            </div>
                        );
                    })}
            </div>
        </div>
    );
};
