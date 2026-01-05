import type { Character } from "../../../domain/value-objects/characters/character";
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

};


export const getStyleForCharacter = (character: Character) => {
  return getCharacterStyle[character.constructor.name];
};
