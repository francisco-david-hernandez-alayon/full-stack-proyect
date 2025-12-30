import type { Scene } from "../../../domain/entities/scenes/scene";
import { SceneType } from "../../../application/enumerates/scene-type";

// Map each scene type (class) to its folder/image path
export const getSceneStyle: Record<
    string,
    { image: string, name: string  }
> = {
    ChangeBiomeScene: {
        image: "/images/scenes/cambiar_blanco.png",
        name: "Change Biome"
    },
    FinalScene: {
        image: "/images/scenes/cambiar_blanco.png",
        name: "Final Scene"
    },
    EnemyScene: {
        image: "/images/scenes/enemigo_blanco.png",
        name: "Enemy"
    },
    ItemScene: {
        image: "/images/scenes/recoger_blanco.png",
        name: "Item"
    },
    NothingHappensScene: {
        image: "/images/scenes/paisaje_blanco.png",
        name: "Nothing Happens"
    },
    TradeScene: {
        image: "/images/scenes/mercado_blanco.png",
        name: "Trade"
    },
};

export const getStyleForScene = (scene: Scene) => {
    return getSceneStyle[scene.constructor.name];
};


export const sceneTypeStyle: Record<
    SceneType,
    { image: string, name: string }
> = {
    [SceneType.ChangeBiome]: {
        image: "/images/scenes/cambiar_blanco.png",
        name: "Change Biome"
    },
    [SceneType.Final]: {
        image: "/images/scenes/cambiar_blanco.png",
        name: "Final Scene"
    },
    [SceneType.Enemy]: {
        image: "/images/scenes/enemigo_blanco.png",
        name: "Enemy"
    },
    [SceneType.Item]: {
        image: "/images/scenes/recoger_blanco.png",
        name: "Item"
    },
    [SceneType.NothingHappens]: {
        image: "/images/scenes/paisaje_blanco.png",
        name: "Nothing Happens"
    },
    [SceneType.Trade]: {
        image: "/images/scenes/mercado_blanco.png",
        name: "Trade"
    },
    [SceneType.None]: {
        image: "", // fallback
        name: "Unknown"
    },
};

export const getStyleForSceneType = (sceneType: SceneType) => {
    return sceneTypeStyle[sceneType];
};
