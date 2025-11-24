export class GameJsonResponse {
    constructor(json) {
        if (!json) throw new TypeError("json response is required");

        this.id = json.id;

        this.character = {
            type: json.character.type,
            currentHealthPoints: json.character.currentHealthPoints,
            currentFoodPoints: json.character.currentFoodPoints,
            currentMoney: json.character.currentMoney,
            inventoryList: json.character.inventoryList ?? [],
        };

        this.numberScenesToFinish = json.numberScenesToFinish;

        this.listCompletedScenes =
            json.listCompletedScenes?.map(scene => this.#mapScene(scene)) ?? [];

        this.listCurrentScenes =
            json.listCurrentScenes?.map(scene => this.#mapScene(scene)) ?? [];

        this.listCurrentUserActions = json.listCurrentUserActions ?? [];

        this.finalScene = {
            name: json.finalScene.name,
            description: json.finalScene.description,
            biome: json.finalScene.biome,
        };

        this.currentEnemy = json.currentEnemy
            ? {
                  name: json.currentEnemy.name,
                  healthPoints: json.currentEnemy.healthPoints,
                  damageAttack: json.currentEnemy.damageAttack,
                  speedAttack: json.currentEnemy.speedAttack,
                  moneyReward: json.currentEnemy.moneyReward,
              }
            : null;
    }

    #mapScene(scene) {
        return {
            id: scene.id,
            name: scene.name,
            description: scene.description,
            biome: scene.biome,
            sceneType: scene.sceneType,

            enemy: scene.enemy ?? null,
            possibleScenes: scene.possibleScenes ?? null,
            rewardItem: scene.rewardItem ?? null,

            characterItemsOffer: scene.characterItemsOffer ?? null,
            characterMoneyOffer: scene.characterMoneyOffer ?? null,
            merchantItemsOffer: scene.merchantItemsOffer ?? null,
            merchantMoneyOffer: scene.merchantMoneyOffer ?? null,
        };
    }

}
