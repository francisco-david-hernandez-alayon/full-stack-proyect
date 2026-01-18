import { BerserkerCharacter } from "../../../domain/value-objects/characters/berserker-character";
import { ExplorerCharacter } from "../../../domain/value-objects/characters/explorer-character";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import type { AlertData } from "../App";
import { CharacterCard } from "../components/Cards/CharacterCard";

interface CharacterPageProps {
  showAlert: (data: AlertData) => void;
}


export const CharactersPage: React.FC<CharacterPageProps> = ({ showAlert }) => {
  const warrior = new WarriorCharacter();
  const thief = new ThiefCharacter();
  const berserker = new BerserkerCharacter();
  const explorer = new ExplorerCharacter();

  return (
    <div className="flex flex-col align-center p-6">
      <h1 className="text-custom-primary-title">Characters</h1>
      <div className="grid grid-cols-2 md:grid-cols-4 gap-6">
        <CharacterCard character={warrior} />
        <CharacterCard character={thief} />
        <CharacterCard character={berserker} />
        <CharacterCard character={explorer} />
      </div>
    </div>
  );
};
