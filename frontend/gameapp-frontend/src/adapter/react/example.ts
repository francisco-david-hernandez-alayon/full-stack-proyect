import { EnemyHttpRepository } from "../http/repository/enemy-http-repository";
import { GameHttpRepository } from "../http/repository/game-http-repository";
import { ItemHttpRepository } from "../http/repository/item-http-repository";
import { SceneHttpRepository } from "../http/repository/scene-http-repository";
import { Game } from "../../domain/entities/game";
import { Scene } from "../../domain/entities/scenes/scene";
import { Item } from "../../domain/entities/items/item";
import { Enemy } from "../../domain/entities/enemy";

const repoGame = new GameHttpRepository();
const repoScene = new SceneHttpRepository();
const repoItem = new ItemHttpRepository();
const repoEnemy = new EnemyHttpRepository();

(async () => {
  try {
    // GET ALL GAMES
    console.log("--------------------> Response GET all games:");
    const allGames: Game[] = await repoGame.fetchAll();
    allGames.forEach((game: Game) => {
      console.log(game.toString());
    });

    // GET ALL SCENES
    console.log("--------------------> Response GET all scenes:");
    const allScenes: Scene[] = await repoScene.fetchAll();
    allScenes.forEach((scene: Scene) => {
      console.log(scene.toString());
    });

    // GET ALL ITEMS
    console.log("--------------------> Response GET all items:");
    const allItems: Item[] = await repoItem.fetchAll();
    allItems.forEach((item: Item) => {
      console.log(item.toString());
    });

    // GET ALL ENEMIES
    console.log("--------------------> Response GET all enemies:");
    const allEnemies: Enemy[] = await repoEnemy.fetchAll();
    allEnemies.forEach((enemy: Enemy) => {
      console.log(enemy.toString());
    });

  } catch (err) {
    console.error("error in requests: ", err);
  }
})();
