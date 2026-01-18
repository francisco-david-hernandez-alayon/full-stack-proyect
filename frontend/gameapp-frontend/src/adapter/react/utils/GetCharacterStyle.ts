import { BerserkerCharacter } from "../../../domain/value-objects/characters/berserker-character";
import type { Character } from "../../../domain/value-objects/characters/character";
import { ExplorerCharacter } from "../../../domain/value-objects/characters/explorer-character";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";

const getCharacterStyle: Record<
  string,
  {
    image: string;
    description: string;
    abilityName: string;
    abilityDescription: string;
  }
> = {
  WarriorCharacter: {
    image: "/images/characters/caballero.png",
    description: "A well-balanced starting character designed for new players. Reliable in combat and survival, making it the perfect choice to begin your journey.",
    abilityName: "Powerful Strike",
    abilityDescription: `When hitting ${WarriorCharacter.HITS_NEEDED_TO_GET_ABILITY} enemies, can deal ${WarriorCharacter.ABILITY_DAMAGE} damage to the current enemy without receiving damage.`,
  },
  ThiefCharacter: {
    image: "/images/characters/ladron.png",
    description: "A fast and agile thief who thrives on stealth and greed. Excels at taking down enemies quickly and walking away with more gold.",
    abilityName: "Stealthy Robbery",
    abilityDescription: `When killing an enemy, gains ${ThiefCharacter.EXTRA_MONEY_WHEN_KILL_ENEMY} extra gold.`,
  },
  BerserkerCharacter: {
    image: "/images/characters/berserker.png",
    description: "A formidable warrior who doesn't tolerate hunger well but is lethal in combat.",
    abilityName: "Berserker healing",
    abilityDescription: `When killing ${BerserkerCharacter.KILLS_NEEDED_TO_GET_ABILITY} enemies, can heal ${BerserkerCharacter.ABILITY_CURE} health`,
  },
  ExplorerCharacter: {
    image: "/images/characters/explorador.png",
    description: "A brave adventurer who, while not skilled in combat, is prepared for exploration, survival, and item collection.",
    abilityName: "Object exploration",
    abilityDescription: `When you visit ${ExplorerCharacter.NOTHING_HAPPENS_SCENES_NEEDED} "Nothing Happens Scene" scenes, you can search for a random common item (${ExplorerCharacter.PROBABILITY_OF_RARE_ITEM}% chance of getting a rare item).`,
  },

};


export const getStyleForCharacter = (character: Character) => {
  return getCharacterStyle[character.constructor.name];
};
