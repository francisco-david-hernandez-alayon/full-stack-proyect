export class SceneJsonResponse {
    constructor(json) {
        if (!json) throw new TypeError("json response is required");

        this.id = json.id;
        this.name = json.name;
        this.description = json.description;
        this.biome = json.biome;
        this.sceneType = json.sceneType;

        // EnemyScene
        this.enemy = json.enemy ? this.#mapEnemy(json.enemy) : null;

        // EnterDungeonScene
        this.possibleScenes = json.possibleScenes
            ? json.possibleScenes.map(s => new SceneJsonResponse(s))
            : null;

        // ItemScene
        this.rewardItem = json.rewardItem
            ? this.#mapItem(json.rewardItem)
            : null;

        // TradeScene
        this.characterItemsOffer = json.characterItemsOffer?.map(i =>
            this.#mapItem(i)
        ) ?? null;

        this.characterMoneyOffer = json.characterMoneyOffer ?? null;

        this.merchantItemsOffer = json.merchantItemsOffer?.map(i =>
            this.#mapItem(i)
        ) ?? null;

        this.merchantMoneyOffer = json.merchantMoneyOffer ?? null;
    }

    #mapEnemy(enemy) {
        return {
            name: enemy.name,
            healthPoints: enemy.healthPoints,
            damageAttack: enemy.damageAttack,
            speedAttack: enemy.speedAttack,
            moneyReward: enemy.moneyReward,
        };
    }

    #mapItem(item) {
        return {
            name: item.name,
            description: item.description,
            itemType: item.itemType,

            healthPointsReceived: item.healthPointsReceived ?? null,
            foodPointsReceived: item.foodPointsReceived ?? null,
            attackDamage: item.attackDamage ?? null,
            speedAttack: item.speedAttack ?? null,
            durability: item.durability ?? null,
        };
    }
}
