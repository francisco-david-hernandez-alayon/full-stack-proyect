import type { Scene } from "../../../domain/entities/scenes/scene";
import { getStyleForBiome } from "../utils/GetBiomeStyle";
import { getStyleForScene } from "../utils/GetSceneStyle";

interface SceneCardProps {
    scene: Scene
}

interface SceneCardProps {
    scene: Scene
}

export const SceneCard: React.FC<SceneCardProps> = ({ scene }) => {
    const biomeStyle = getStyleForBiome(scene.biome);
    const sceneStyle = getStyleForScene(scene);

    return (
        <div
            className="flex flex-col items-center justify-start p-4 rounded-2xl text-white font-semibold w-full h-full"
            style={{ backgroundColor: biomeStyle.color }}
        >

            <div className="flex items-center gap-2 mb-2">
                <img
                    src={biomeStyle.image}
                    alt={scene.biome}
                    className="h-10 w-10 object-contain"
                />
                <div className="text-lg font-bold">{scene.name.name}</div>
            </div>

            <div className="text-sm mb-2">{scene.biome}</div>

            <div className="divider w-full my-2"></div>

            <div className="text-xs text-center text-custom-background">
                {scene.description.description}
            </div>

            <img
                    src={sceneStyle.image}
                    alt={scene.name.name}
                    className="h-10 w-10 object-contain"
                />
        </div>
    );

};
