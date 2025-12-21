import type { Scene } from "../../../domain/entities/scenes/scene";

// Map each scene type (class) to its folder/image path
export const getSceneStyle: Record<
    string,
    { image: string }
> = {
    ChangeBiomeScene: {
        image: "/images/scenes/cambiar_blanco.png",
    },
    EnemyScene: {
        image: "/images/scenes/enemigo_blanco.png",
    },
    ItemScene: {
        image: "/images/scenes/recoger_blanco.png",
    },
    NothingHappensScene: {
        image: "/images/scenes/paisaje_blanco.png",
    },
    TradeScene: {
        image: "/images/scenes/mercado_blanco.png",
    },
};

export const getStyleForScene = (scene: Scene) => {
    return getSceneStyle[scene.constructor.name];
};
