import { Character } from "../../../domain/value-objects/characters/character";
import { Item } from "../../../domain/entities/items/item";
import { ItemJsonRequest } from "./item-json-request";
import { CharacterType } from "../../../application/enumerates/character-type";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";
import { BerserkerCharacter } from "../../../domain/value-objects/characters/berserker-character";
import { ExplorerCharacter } from "../../../domain/value-objects/characters/explorer-character";

export class CharacterJsonRequest {
    type: CharacterType;
    currentHealthPoints: number;
    currentFoodPoints: number;
    currentMoney: number;
    inventoryList: ItemJsonRequest[];

    // optional atributes
    currentHits?: number;
    currentKills?: number;
    currentNothingHappensScenes?: number;

    constructor(character: Character) {
        if (!character) throw new TypeError("character is required");
        if (!(character instanceof Character)) throw new TypeError("character must be an instance of Character");

        if (!Number.isInteger(character.currentHealthPoints)) {
            throw new TypeError("currentHealthPoints must be an integer");
        }
        if (!Number.isInteger(character.currentFoodPoints)) {
            throw new TypeError("currentFoodPoints must be an integer");
        }
        if (!Number.isInteger(character.currentMoney)) {
            throw new TypeError("currentMoney must be an integer");
        }

        switch (true) {
            case character instanceof WarriorCharacter:
                this.type = CharacterType.Warrior;
                break;

            case character instanceof ThiefCharacter:
                this.type = CharacterType.Thief;
                break;
            
            case character instanceof BerserkerCharacter:
                this.type = CharacterType.Berserker;
                break;
            
            case character instanceof ExplorerCharacter:
                this.type = CharacterType.Explorer;
                break;

            default:
                throw new TypeError(`Unknown character class: '${character.constructor.name}'`);
        }


        this.currentHealthPoints = character.currentHealthPoints;
        this.currentFoodPoints = character.currentFoodPoints;
        this.currentMoney = character.currentMoney;

        this.inventoryList = character.inventoryList.map(item => {
            if (!(item instanceof Item)) {
                throw new TypeError("inventoryList must contain Item instances");
            }
            return new ItemJsonRequest(item);
        });

        if (character instanceof WarriorCharacter) {
            this.currentHits = character.getHits();
        }

        if (character instanceof BerserkerCharacter) {
            this.currentKills = character.getKills();
        }

        if (character instanceof ExplorerCharacter) {
            this.currentNothingHappensScenes = character.getCurrentNothingHappensScenes();
        }

    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
