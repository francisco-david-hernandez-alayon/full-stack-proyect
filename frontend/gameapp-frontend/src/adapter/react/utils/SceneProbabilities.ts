import { SceneType } from "../../../application/enumerates/scene-type";
import { Biome } from "../../../domain/enumerates/biome";


export const sceneProbabilitiesByBiome: Record<Biome, Record<SceneType, number>> = {
    [Biome.CITY]: {
        [SceneType.NothingHappens]: 5,
        [SceneType.Item]: 15,
        [SceneType.Enemy]: 20,
        [SceneType.Trade]: 30,
        [SceneType.ChangeBiome]: 30,
        [SceneType.None]: 0,
    },

    [Biome.FOREST]: {
        [SceneType.NothingHappens]: 15,
        [SceneType.Item]: 25,
        [SceneType.Enemy]: 30,
        [SceneType.Trade]: 10,
        [SceneType.ChangeBiome]: 20,
        [SceneType.None]: 0,
    },

    [Biome.DESERT]: {
        [SceneType.NothingHappens]: 35,
        [SceneType.Item]: 20,
        [SceneType.Enemy]: 20,
        [SceneType.Trade]: 10,
        [SceneType.ChangeBiome]: 15,
        [SceneType.None]: 0,
    },

    [Biome.SWAMP]: {
        [SceneType.NothingHappens]: 10,
        [SceneType.Item]: 15,
        [SceneType.Enemy]: 45,
        [SceneType.Trade]: 10,
        [SceneType.ChangeBiome]: 20,
        [SceneType.None]: 0,
    },

    [Biome.UNKNOWN]: {
        [SceneType.NothingHappens]: 0,
        [SceneType.Item]: 0,
        [SceneType.Enemy]: 0,
        [SceneType.Trade]: 0,
        [SceneType.ChangeBiome]: 0,
        [SceneType.None]: 0,
    }
};
