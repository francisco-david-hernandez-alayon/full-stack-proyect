import React from "react";
import type { Character } from "../../../../domain/value-objects/characters/character";
import { WarriorCharacter } from "../../../../domain/value-objects/characters/warrior-character";
import { getStyleForCharacter } from "../../utils/GetCharacterStyle";

interface CharacterAbilityButtonProps {
    character: Character;
    onUseAbility: () => void;
}

export const CharacterAbilityButton: React.FC<CharacterAbilityButtonProps> = ({
    character,
    onUseAbility,
}) => {
    const style = getStyleForCharacter(character);
    let canUseAbility = false;

    if (character instanceof WarriorCharacter) {
        if (character.canUseAbility()) {
            canUseAbility = true;
        }
        
    }


    return (
        <div className="relative inline-block group text-center">
            {/* Circular Button */}
            <div

                className="flex flex-col items-center justify-center gap-3 w-35 h-35 p-5  text-custom-secondary"
            >
                <button className="btn btn-secondary font-semibold text-sm" onClick={onUseAbility} disabled={!canUseAbility}>{style.abilityName}</button>

                {character instanceof WarriorCharacter ?
                    (<div>
                        <span className="text-xm opacity-90">{character.getHits()}/{WarriorCharacter.HITS_NEEDED_TO_GET_ABILITY} hits</span>
                    </div>)
                    : null}

            </div>

            {/* Tooltip */}
            <div className="absolute left-1/2 transform -translate-x-1/2 -top-35 w-56 p-2 bg-custom-background border border-secondary rounded-lg shadow-lg opacity-0 pointer-events-none transition-opacity duration-200 group-hover:opacity-100 z-50">
                <p className="text-sm font-semibold">{style.abilityName}</p>
                <p className="text-sm">{style.abilityDescription}</p>
            </div>
        </div>
    );
};
