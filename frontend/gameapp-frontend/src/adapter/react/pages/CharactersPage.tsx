import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { CharacterCard } from "../components/CharacterCard";

export const CharactersPage: React.FC = () => {
  const warrior = new WarriorCharacter();

  return (
    <div className="p-6">
      <h1 className="text-custom-primary-title">Characters</h1>
      <div className="grid grid-cols-2 md:grid-cols-4 gap-6">
        <CharacterCard character={warrior} />
      </div>
    </div>
  );
};
