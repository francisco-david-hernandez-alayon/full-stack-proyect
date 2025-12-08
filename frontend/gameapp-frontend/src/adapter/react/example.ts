import { EnemyHttpRepository } from "../http/repository/enemy-http-repository";
import { GameHttpRepository } from "../http/repository/game-http-repository";
import { ItemHttpRepository } from "../http/repository/item-http-repository";
import { SceneHttpRepository } from "../http/repository/scene-http-repository";
import { Game } from "../../domain/entities/game";
import { Scene } from "../../domain/entities/scenes/scene";
import { Item } from "../../domain/entities/items/item";
import { Enemy } from "../../domain/entities/enemy";
import { WarriorCharacter } from "../../domain/value-objects/characters/warrior-character";
import { NothingHappensScene } from "../../domain/entities/scenes/nothing-happens-scene";
import { UserAction } from "../../domain/enumerates/user-action";
import { GameAdvanceSceneService } from "../../application/services/game-services/game-advance-scene-service";
import { GameCreateService } from "../../application/services/game-services/game-create-service";
import { GameGetService } from "../../application/services/game-services/game-get-service";
import { SceneGetService } from "../../application/services/scene-services/scene-get-service";

const repoGame = new GameHttpRepository();
const repoScene = new SceneHttpRepository();
const repoItem = new ItemHttpRepository();
const repoEnemy = new EnemyHttpRepository();

const sceneGetService = new SceneGetService(repoScene);
const gameAdvanceSceneService = new GameAdvanceSceneService(repoGame);
const gameCreateService = new GameCreateService(repoGame);

(async () => {
  try {
    // // GET ALL GAMES
    // console.log("--------------------> Response GET all games:");
    // const allGames: Game[] = await repoGame.fetchAll();
    // allGames.forEach((game: Game) => {
    //   console.log(game.toString());
    // });

    // // GET ALL SCENES
    // console.log("--------------------> Response GET all scenes:");
    // const allScenes: Scene[] = await repoScene.fetchAll();
    // allScenes.forEach((scene: Scene) => {
    //   console.log(scene.toString());
    // });

    // // GET ALL ITEMS
    // console.log("--------------------> Response GET all items:");
    // const allItems: Item[] = await repoItem.fetchAll();
    // allItems.forEach((item: Item) => {
    //   console.log(item.toString());
    // });

    // // GET ALL ENEMIES
    // console.log("--------------------> Response GET all enemies:");
    // const allEnemies: Enemy[] = await repoEnemy.fetchAll();
    // allEnemies.forEach((enemy: Enemy) => {
    //   console.log(enemy.toString());
    // });


    // GET ALL SCENES
    const allScenes: Scene[] = await sceneGetService.getAllScenes();

    const finalScene = allScenes.find(s => s instanceof NothingHappensScene);  // search nothing happens scene to make final scene
    if (!finalScene) {
      throw new Error("No NothingHappensScene found in all scenes.");
    }


    // POST GAME AND GENERATE NEW SCENE
    console.log("Response POST GAME");

    const gamePosted: Game = await gameCreateService.createGame(new WarriorCharacter(), 10, finalScene, [finalScene], [UserAction.MOVE_FORWARD]);
    console.log(gamePosted.toString());

    console.log("Response POST GAME");

    let gameGeneratingScenes: Game = gamePosted;
    let sceneSelected: Scene;

    for (let i = 0; i < 20; i++) {

      sceneSelected = gameGeneratingScenes.currentScenes[0];
      gameGeneratingScenes = await gameAdvanceSceneService.advance(sceneSelected.id, gameGeneratingScenes);

      console.log("game generated '" + i + "' ==> {{{---" + gameGeneratingScenes.toString() + "---}}}");
    }



  } catch (err) {
    console.error("error in requests: ", err);
  }
})();
