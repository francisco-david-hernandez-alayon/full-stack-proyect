import { WarriorCharacter } from "./domain/value-objects/characters/warrior-character.js";
import { Game } from "./domain/entities/game.js";

import { NothingHappensScene } from './domain/value-objects/scenes/nothing-happens-scene.js';
import {EnemyScene} from './domain/value-objects/scenes/enemy-scene.js';
import { ItemScene } from './domain/value-objects/scenes/item-scene.js';
import {SceneName} from './domain/value-objects/scenes/scene-name.js';
import { SceneDescription} from './domain/value-objects/scenes/scene-description.js';

import { AtributeItem } from "./domain/value-objects/items/attribute-item.js";
import { Biome } from './domain/enumerates/biome.js'
import { EnemyName } from './domain/value-objects/enemies/enemy-name.js'
import { Enemy } from './domain/value-objects/enemies/enemy.js'
import { ItemName } from "./domain/value-objects/items/item-name.js";
import { ItemDescription } from "./domain/value-objects/items/item-description.js";
import { UserAction } from "./domain/enumerates/user-action.js";

// Create character
const warrior = new WarriorCharacter();

// Create example item
const healthPotion = new AtributeItem(
    new ItemName("Health Potion"), 
    new ItemDescription("Restore 50hp"), 
    50, 0
);

// Create scenes
const nothingScene = new NothingHappensScene(
    new SceneName("Peaceful Meadow"),
    new SceneDescription("A calm and peaceful area"),
    Biome.FOREST
);

const itemScene = new ItemScene(
    new SceneName("Treasure Chest"),
    new SceneDescription("You found a treasure chest with an item"),
    Biome.CITY,
    healthPotion
);

const enemy = new Enemy(
    new EnemyName("Goblin"),
    30, 5, 2, 10
);

const enemyScene = new EnemyScene(
    new SceneName("Goblin Ambush"),
    new SceneDescription("A wild goblin attacks!"),
    Biome.FOREST,
    enemy
);

// Create currentUserActions
const currentUserActions = [UserAction.MOVE_FORWARD, UserAction.USE_ITEM] 


// Create game
const game = new Game(
    warrior,
    10,
    nothingScene,
    [itemScene, enemyScene],
    currentUserActions,
    [nothingScene, itemScene, nothingScene, itemScene, enemyScene],
    
);


// Mostrar por pantalla usando toString
console.log(game.toString());
