import { Scene } from "../../../../domain/entities/scenes/scene";
import { getStyleForBiome } from "../../utils/GetBiomeStyle";
import { getStyleForScene } from "../../utils/GetSceneStyle";

interface SceneCardProps {
    scene: Scene
    getMoveForwardSceneId: (sceneId: string) => void;
    canMoveForward: boolean;
}

export const SceneCard: React.FC<SceneCardProps> = ({ scene, getMoveForwardSceneId, canMoveForward }) => {
    const biomeStyle = getStyleForBiome(scene.biome);
    const sceneStyle = getStyleForScene(scene);

    return (
        <div
            className="flex flex-col items-center justify-start p-4 rounded-2xl text-white font-semibold w-full h-full max-w-3xl"
            style={{ backgroundColor: biomeStyle.color }}
        >

            {/* Scene Title */}
            <div className="flex items-center gap-5 mb-2">
                <img
                    src={biomeStyle.image}
                    alt={scene.biome}
                    className="h-15 w-15 object-contain"
                />
                <div>
                    <div className="text-lg font-bold">{scene.name.name}</div>
                    <div className="text-sm mb-2">{scene.biome}</div>
                </div>

            </div>

            <div className="divider w-full my-2"></div>

            {/* Scene Description */}
            <div className="flex flex-col items-center">
                <img
                    src={sceneStyle.image}
                    alt={scene.name.name}
                    className="h-20 w-20 object-contain"
                />

                <div className="text-xs text-center text-custom-background p-5">
                    {scene.description.description}
                </div>
            </div>


            {/* Actions */}
            <button
                className="btn btn-primary mt-4"
                disabled={!canMoveForward}
                onClick={() => getMoveForwardSceneId(scene.id)}
            >
                Move forward
            </button>

        </div>
    );

};
