import { Activity, DollarSign, Ham, Heart, Sword, Backpack } from "lucide-react";
import { Character } from "../../../domain/value-objects/characters/character";
import { getStyleForCharacter } from "../utils/GetCharacterStyle";

interface CharacterCardProps {
  character: Character;
}

export const CharacterCard: React.FC<CharacterCardProps> = ({ character }) => {
  return (
    <div className="card bg-base-100 shadow-xl max-w-md">
      <div className="card-body gap-4 pa-2">
        {/* Top row: image + name | description */}
        <div className="flex gap-4 items-center">
          <div className="flex flex-col items-center w-28 flex-none">
            <img
              src={getStyleForCharacter(character).image}
              alt={character.constructor.name}
              className="h-20 w-20"
            />

            <h2 className="card-title text-custom-primary-title text-center text-sm mt-2">
              {character.name.name}
            </h2>
          </div>

          {/* Right: description */}
          <p className="text-sm text-custom-secondary opacity-80">
            A well-balanced starting character designed for new players. Reliable
            in combat and survival, making it the perfect choice to begin your
            journey.
          </p>
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
              <Activity className="w-4 h-4" />
              <span>Speed</span>
            </div>
            <span>{character.attackSpeed}</span>
          </div>
        </div>
      </div>
    </div>
  );
};
