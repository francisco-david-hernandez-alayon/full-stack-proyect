import { Character } from "../../../domain/value-objects/characters/character.js";
import { Item } from "../../../domain/entities/items/item.js";
import { ItemJsonRequest } from "./item-json-request.js";
import { CharacterType } from "../enumerates/character-type.js";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character.js";

export class CharacterJsonRequest {
    constructor(character) {
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
            throw new TypeError(`Unknown character class: '${character}'`);
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

    toString() {
        return JSON.stringify(this, null, 2);
    }
}
