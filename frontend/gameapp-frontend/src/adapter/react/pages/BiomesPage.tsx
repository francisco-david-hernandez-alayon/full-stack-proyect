import { Biome } from "../../../domain/enumerates/biome";
import type { AlertData } from "../App";
import { BiomeCard } from "../components/Cards/BiomeCard";
import { getStyleForBiome } from "../utils/GetBiomeStyle";
import { sceneProbabilitiesByBiome } from "../utils/SceneProbabilities";

interface BiomesPageProps {
  showAlert: (data: AlertData) => void;
}


export const BiomesPage: React.FC<BiomesPageProps> = ({ showAlert }) => {

  return (
    <>
      <div className="p-6">
        <h1 className="text-custom-primary-title">Biomes</h1>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <BiomeCard
            key={Biome.FOREST}
            biome={Biome.FOREST}
            description="Lush forests with abundant resources and minimal threats. Ideal for settlers seeking peace and balance. The canopy provides shelter from harsh weather, while wildlife thrives in harmony. Travelers can find plenty of edible plants and fresh water, making it a prime location for long-term settlement."
            color={getStyleForBiome(Biome.FOREST).color}
            image={getStyleForBiome(Biome.FOREST).image}
            sceneProbabilities={sceneProbabilitiesByBiome[Biome.FOREST]}
          />

          <BiomeCard
            key={Biome.DESERT}
            biome={Biome.DESERT}
            description="Harsh desert environment with scarce water and extreme heat. Survival is challenging, beware of hidden dangers. Sandstorms can arise without warning, and food sources are limited. Despite its harshness, rare oases and unique desert flora can be discovered by the vigilant explorer."
            color={getStyleForBiome(Biome.DESERT).color}
            image={getStyleForBiome(Biome.DESERT).image}
            sceneProbabilities={sceneProbabilitiesByBiome[Biome.DESERT]}
          />

          <BiomeCard
            key={Biome.SWAMP}
            biome={Biome.SWAMP}
            description="Murky swamps filled with disease and treacherous terrain. Travel cautiously, predators are common. Thick fog often obscures vision, and the ground can be deceptively unstable. Despite the dangers, swamps harbor rare herbs and creatures that cannot be found elsewhere, rewarding the brave and patient."
            color={getStyleForBiome(Biome.SWAMP).color}
            image={getStyleForBiome(Biome.SWAMP).image}
            sceneProbabilities={sceneProbabilitiesByBiome[Biome.SWAMP]}
          />

          <BiomeCard
            key={Biome.CITY}
            biome={Biome.CITY}
            description="Bustling city with numerous merchants and opportunities. Crowds and chaos make survival tricky. Streets are alive day and night with trade, gossip, and the clash of different cultures. While wealth and connections abound, petty crime and political intrigue are ever-present challenges for newcomers."
            color={getStyleForBiome(Biome.CITY).color}
            image={getStyleForBiome(Biome.CITY).image}
            sceneProbabilities={sceneProbabilitiesByBiome[Biome.CITY]}
          />

        </div>
      </div>
    </>
  );
};