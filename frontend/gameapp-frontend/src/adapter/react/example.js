

import { EnemyHttpRepository } from "../http/repository/enemy-http-repository.js";
import { GameHttpRepository } from "../http/repository/game-http-repository.js"
import { ItemHttpRepository } from "../http/repository/item-http-repository.js";
import { SceneHttpRepository } from "../http/repository/scene-http-repository.js";



//--------------------------------------------SIMPLE TESTING----------------------------------------//
// import { WarriorCharacter } from "./domain/value-objects/characters/warrior-character.js";
// import { Game } from "./domain/entities/game.js";

// import { NothingHappensScene } from './domain/entities/scenes/nothing-happens-scene.js';
// import { EnemyScene } from './domain/entities/scenes/enemy-scene.js';
// import { ItemScene } from './domain/entities/scenes/item-scene.js';
// import { SceneName } from './domain/value-objects/scenes/scene-name.js';
// import { SceneDescription } from './domain/value-objects/scenes/scene-description.js';

// import { AttributeItem } from "./domain/entities/items/attribute-item.js";
// import { Biome } from './domain/enumerates/biome.js'
// import { EnemyName } from './domain/value-objects/enemies/enemy-name.js'
// import { Enemy } from './domain/entities/enemy.js'
// import { ItemName } from "./domain/value-objects/items/item-name.js";
// import { ItemDescription } from "./domain/value-objects/items/item-description.js";
// import { UserAction } from "./domain/enumerates/user-action.js";

// // Create character
// const warrior = new WarriorCharacter();

// // Create example item
// const healthPotion = new AttributeItem(
//     new ItemName("Health Potion"),
//     new ItemDescription("Restore 50hp"),
//     50, 0
// );

// // Create scenes
// const nothingScene = new NothingHappensScene(
//     new SceneName("Peaceful Meadow"),
//     new SceneDescription("A calm and peaceful area"),
//     Biome.FOREST
// );

// const itemScene = new ItemScene(
//     new SceneName("Treasure Chest"),
//     new SceneDescription("You found a treasure chest with an item"),
//     Biome.CITY,
//     healthPotion
// );

// const enemy = new Enemy(
//     new EnemyName("Goblin"),
//     30, 5, 2, 10
// );

// const enemyScene = new EnemyScene(
//     new SceneName("Goblin Ambush"),
//     new SceneDescription("A wild goblin attacks!"),
//     Biome.FOREST,
//     enemy
// );

// // Create currentUserActions
// const currentUserActions = [UserAction.MOVE_FORWARD, UserAction.USE_ITEM]


// // 1️⃣ Crear el juego
// const game = new Game(
//     warrior,
//     10,
//     nothingScene,
//     [itemScene, enemyScene],
//     currentUserActions,
//     [nothingScene, itemScene, nothingScene, itemScene, enemyScene]
// );



// // Inicializar el repositorio
// const repoGame = new GameHttpRepository("http://localhost:5000/api");

// const repoScene = new SceneHttpRepository("http://localhost:5000/api");

// (async () => {
//     try {

//         // POST
//         console.log("--------------------> Response POST (Create Game):");
//         let createdGame = await repoGame.save(game);
//         console.log(createdGame.toString());

//         // GET ById
//         console.log("--------------------> Response GET by ID:");
//         const fetchedById = await repoGame.fetchById(createdGame.id);
//         console.log(fetchedById.toString());

//         // GET
//         console.log("--------------------> Response GET all games:");
//         const allGames = await repoGame.fetchAll();
//         allGames.forEach(game => {
//             console.log(game.toString());
//         });

//         // PUT 
//         console.log("--------------------> Response PUT (update Game):");
//         createdGame = createdGame.addCompletedScene(itemScene);
//         const newCharacter = createdGame.character.heal(createdGame.character.currentHealthPoints + itemScene.rewardItem.healthPointsReceived);
//         createdGame = createdGame.setCharacter(newCharacter);

//         const updatedGame = await repoGame.update(createdGame.id, createdGame);
//         console.log(updatedGame.toString());

//         // DELETE
//         console.log("--------------------> Response DELETE by ID:");
//         const deleteGame = await repoGame.delete(createdGame.id);
//         console.log(deleteGame.toString());




//         // GET SCENES
//         console.log("--------------------> Response GET all SCENES:");
//         const allScenes = await repoScene.fetchAll();
//         allScenes.forEach(scene => {
//             console.log(scene.toString());
//         });

//     } catch (err) {
//         console.error("❌ Error en las peticiones:", err);
//     }
// })();

// console.log(game.toString());

const repoGame = new GameHttpRepository();
const repoScene = new SceneHttpRepository();
const repoItem = new ItemHttpRepository();
const repoEnemy = new EnemyHttpRepository();

(async () => {
    try {
        // GET ALL GAMES
        console.log("--------------------> Response GET all games:");
        const allGames = await repoGame.fetchAll();
        allGames.forEach(game => {
            console.log(game.toString());
        });


        // GET ALL SCENES
        console.log("--------------------> Response GET all scenes:");
        const allScenes = await repoScene.fetchAll();
        allScenes.forEach(scene => {
            console.log(scene.toString());
        });

        // GET ALL ITEMS
        console.log("--------------------> Response GET all items:");
        const allItems = await repoItem.fetchAll();
        allItems.forEach(item => {
            console.log(item.toString());
        });

        // GET ALL ENEMYS
        console.log("--------------------> Response GET all enemys:");
        const allEnemys = await repoEnemy.fetchAll();
        allEnemys.forEach(enemy => {
            console.log(enemy.toString());
        });

    } catch (err) {
        console.error("error in requests: ", err);
    }
})();
