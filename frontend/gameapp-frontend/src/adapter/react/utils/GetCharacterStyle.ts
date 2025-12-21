import type { Character } from "../../../domain/value-objects/characters/character";

const getCharacterStyle: Record<
  string,
  { image: string }
> = {
  WarriorCharacter: { 
    image: "/images/characters/caballero.png",
  },
};


export const getStyleForCharacter = (character: Character) => {
  return getCharacterStyle[character.constructor.name];
};