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

import { GameHttpRepository } from "./adapter/http/repository/game-http-repository.js"

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


// 1️⃣ Crear el juego
const game = new Game(
    warrior,
    10,
    nothingScene,
    [itemScene, enemyScene],
    currentUserActions,
    [nothingScene, itemScene, nothingScene, itemScene, enemyScene]
);



// Inicializar el repositorio
const repo = new GameHttpRepository("http://localhost:5000/api");

(async () => {
    try {
        // // Show Game
        // console.log("Juego a enviar:");
        // console.log(game.toString());

        // POST
        const createdGame = await repo.save(game);
        console.log("Respuesta POST (Game creado):");
        console.log(createdGame);

        // // GET
        // const fetchedById = await repo.fetchById(game.id);
        // console.log("Respuesta GET por ID:");
        // console.log(fetchedById);

        // // GET
        // const allGames = await repo.fetchAll();
        // console.log("Respuesta GET todos los juegos:");
        // console.log(allGames);

    } catch (err) {
        console.error("❌ Error en las peticiones:", err);
    }
})();



// Mostrar por pantalla usando toString
console.log(game.toString());
