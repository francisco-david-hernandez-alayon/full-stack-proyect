import { DollarSign, Ham, Heart, Sword, Backpack, ActivityIcon } from "lucide-react";
import { getStyleForCharacter } from "../../utils/GetCharacterStyle";
import { Character } from "../../../../domain/value-objects/characters/character";

interface CharacterCardProps {
  character: Character;
}

export const CharacterCard: React.FC<CharacterCardProps> = ({ character }) => {

  const style = getStyleForCharacter(character);

  if (style == null) {
    return (
      <div className="card bg-base-100 shadow-xl max-w-md justify-center items-center">
        Error loading character {character.name.name}
      </div>
    )
  }

  return (
    <div className="card bg-base-100 shadow-xl max-w-md">
      <div className="card-body gap-4 pa-2">
        {/* Top row */}
        <div className="flex gap-4 items-center">
          <div className="flex flex-col items-center  w-28 flex-none">
            <img
              src={style.image}
              alt={character.constructor.name}
              className="h-20 w-20"
            />

            <h2 className="card-title text-custom-primary-title text-center">
              {character.name.name}
            </h2>
          </div>

          <p className="text-sm text-custom-secondary opacity-80"> {style.description} </p>
        </div>

        {/* Stats */}
        <div className="w-full space-y-2 text-custom-secondary pt-2 border-t border-base-300">
          <div className="flex items-center justify-between text-sm">
            <div className="flex items-center gap-2">
              <Heart className="w-4 h-4" />
              <span>Health</span>
            </div>
            <span>{character.maxHealthPoints}</span>
          </div>

          <div className="flex items-center justify-between text-sm">
            <div className="flex items-center gap-2">
              <Ham className="w-4 h-4" />
              <span>Food</span>
            </div>
            <span>{character.maxFoodPoints}</span>
          </div>

          <div className="flex items-center justify-between text-sm">
            <div className="flex items-center gap-2">
              <DollarSign className="w-4 h-4" />
              <span>Gold</span>
            </div>
            <span>{character.startingMoney}</span>
          </div>

          <div className="flex items-center justify-between text-sm">
            <div className="flex items-center gap-2">
              <Backpack className="w-4 h-4" />
              <span>Inventory</span>
            </div>
            <span>{character.maxInventorySlots}</span>
          </div>

          <div className="flex items-center justify-between text-sm">
            <div className="flex items-center gap-2">
              <Sword className="w-4 h-4" />
              <span>Damage</span>
            </div>
            <span>{character.attackDamage}</span>
          </div>

          <div className="flex items-center justify-between text-sm">
            <div className="flex items-center gap-2">
              <ActivityIcon className="w-4 h-4" />
              <span>Speed</span>
            </div>
            <span>{character.attackSpeed}</span>
          </div>
        </div>


        {/* Ability */}
        <div>
          <p className="mt-2 text-sm">
            <span className="text-custom-primary font-bold">
              {style.abilityName}
            </span>
            : {style.abilityDescription}
          </p>
        </div>

      </div>
    </div>
  );
};
