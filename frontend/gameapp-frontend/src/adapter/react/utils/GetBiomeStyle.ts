import { Biome } from "../../../domain/enumerates/biome";

// map each biome to a color
const getBiomeStyle: Record<
    Biome,
    { color: string; image: string }
> = {
    [Biome.FOREST]: {
        color: "var(--color-forest)",
        image: "/images/biomes/bosque_blanco.png",
    },
    [Biome.DESERT]: {
        color: "var(--color-desert)",
        image: "/images/biomes/desierto_blanco.png",
    },
    [Biome.SWAMP]: {
        color: "var(--color-swamp)",
        image: "/images/biomes/pantano_blanco.png",
    },
    [Biome.CITY]: {
        color: "var(--color-city)",
        image: "/images/biomes/ciudad_blanco.png",
    },
    [Biome.UNKNOWN]: {
        color: "var(--color-unknown)",
        image: "",
    },
};

export const getStyleForBiome = (biome: Biome) => {
  return getBiomeStyle[biome];
};