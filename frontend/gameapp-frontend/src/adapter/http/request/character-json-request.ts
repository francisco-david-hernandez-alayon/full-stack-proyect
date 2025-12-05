import { Character } from "../../../domain/value-objects/characters/character";
import { Item } from "../../../domain/entities/items/item";
import { ItemJsonRequest } from "./item-json-request";
import { CharacterType } from "../enumerates/character-type";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";

export class CharacterJsonRequest {
    type: CharacterType;
    currentHealthPoints: number;
    currentFoodPoints: number;
    currentMoney: number;
    inventoryList: ItemJsonRequest[];

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

        if (character instanceof WarriorCharacter) {
            this.type = CharacterType.Warrior;
        } else {
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
    }

    toString(): string {
        return JSON.stringify(this, null, 2);
    }
}
