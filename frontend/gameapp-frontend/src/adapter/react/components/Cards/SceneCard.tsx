import type React from "react";
import { ItemScene } from "../../../../domain/entities/scenes/item-scene";
import { Scene } from "../../../../domain/entities/scenes/scene";
import { getStyleForBiome } from "../../utils/GetBiomeStyle";
import { getStyleForScene } from "../../utils/GetSceneStyle";
import { ItemToolTip } from "../Game/ItemToolTip";
import type { Item } from "../../../../domain/entities/items/item";
import { getStyleForItem, ItemImageColor } from "../../utils/GetItemStyle";
import { Enemy } from "../../../../domain/entities/enemy";
import { EnemyScene } from "../../../../domain/entities/scenes/enemy-scene";
import { ActivityIcon, AlertCircle, DiamondPlusIcon, DollarSign, Hand, Heart, Skull, Sword } from "lucide-react";
import { TradeScene } from "../../../../domain/entities/scenes/trade-scene";

interface itemSceneCardProps {
    item: Item
}

const ItemSceneCard: React.FC<itemSceneCardProps> = ({ item }) => {
    return (
        <div className="relative group flex flex-col gap-2 items-center justify-center border rounded-xl w-20 h-25">
            <ItemToolTip item={item} />

            <img
                src={getStyleForItem(item, ItemImageColor.WHITE).image}
                alt={item.name.name}
                className="h-10 w-10 object-contain"
            />

            <div className="text-xs text-center text-custom-background">
                {item.name.name}
            </div>
        </div>
    )
}

interface enemySceneCardProps {
    enemy: Enemy
    currentEnemyHp?: number
    enemyIsDead?: boolean
}

const EnemySceneCard: React.FC<enemySceneCardProps> = ({ enemy, enemyIsDead = false, currentEnemyHp = enemy.healthPoints }) => {
    return (<div className="flex flex-col items-center justify-center border rounded-xl w-85 h-45">
        <div className="text-2xl text-custom-background ">
            {enemy.name.name}
        </div>

        <div className="flex flex-row gap-4 items-center justify-center text-custom-background">

            {/* IMAGE and HP */}
            <div className="flex flex-col items-center gap-3">
                <img
                    src="/images/scenes/enemigo_blanco.png"
                    alt={enemy.name.name}
                    className="h-16 w-16 object-contain"
                />

                <div className="flex flex-row gap-1 items-center justify-center text-xl">
                    {enemyIsDead ? (
                        <Skull className="text-custom-background w-6 h-6" />
                    ) : (
                        <>
                            <span>{currentEnemyHp}/{enemy.healthPoints}</span>
                            <Heart className="w-6 h-6 text-custom-background" />
                        </>
                    )}

                </div>
            </div>

            {/* Stats */}
            <div className="flex flex-col gap-1 text-xm">
                
                <div className="flex items-center gap-2">
                    <AlertCircle className="w-4 h-4 " />
                    <span>{enemy.difficulty}</span>
                </div>

                <div className="flex items-center gap-2">
                    <Sword className="w-4 h-4 " />
                    <span>Damage: {enemy.attackDamage}</span>
                </div>

                <div className="flex items-center gap-2">
                    <ActivityIcon className="w-4 h-4 " />
                    <span>Speed: {enemy.speedAttack}</span>
                </div>

                <div className="flex items-center gap-2">
                    <DiamondPlusIcon className="w-4 h-4" />
                    <span>{enemy.criticalDamage.criticalProbability}% of {enemy.criticalDamage.extraDamage} extra damage</span>
                </div>

                <div className="flex items-center gap-2">
                    <DollarSign className="w-4 h-4" />
                    <span>Reward Money: {enemy.rewardMoney}</span>
                </div>
            </div>
        </div>
    </div>
    );
};


//----------------------------------------------------------------------------------SCENE-CARD----------------------------------------------------------------------------------------------//

interface SceneCardProps {
    CharacterInScene: boolean   // Whether the character is on scene or it's a scene to choose from the current scenes list
    scene: Scene

    // Move scene
    canMoveForward: boolean;
    getMoveForwardSceneId: (sceneId: string) => void;

    // item
    sceneItemExist?: boolean;
    useSceneItem: (currentScene: Scene) => void;
    getSceneItem: (currentScene: Scene) => void;

    // enemy
    canAttackWithoutItem: boolean;
    attackWithoutItem: () => void;
    currentEnemyHp?: number;
    enemyIsDead?: boolean;

    // trade
    characterCurrentMoney?: number;
    characterInventory?: Item[];
    sellItem: (posItemCharacterInventory: number) => void;
    buyItem: (posItemTraderInventory: number) => void;

}

export const SceneCard: React.FC<SceneCardProps> = ({ CharacterInScene, scene,
    canMoveForward, getMoveForwardSceneId,
    sceneItemExist, useSceneItem, getSceneItem,
    canAttackWithoutItem, attackWithoutItem, currentEnemyHp, enemyIsDead,
    characterCurrentMoney, characterInventory, sellItem, buyItem
}) => {

    const biomeStyle = getStyleForBiome(scene.biome);
    const sceneStyle = getStyleForScene(scene);

    return (
        <div
            className="flex flex-col items-center justify-start p-4 rounded-2xl text-custom-background font-semibold w-full h-full max-w-3xl"
            style={{ backgroundColor: biomeStyle.color }}
        >

            {/* Scene Title */}
            <div className="flex items-center gap-5 mb-2">
                <img
                    src={biomeStyle.image}
                    alt={scene.biome}
                    className="h-15 w-15 object-contain"
                />
                <div>
                    <div className="text-lg font-bold">{scene.name.name}</div>
                    <div className="text-sm mb-2">{scene.biome}</div>
                </div>

                <img
                    src={sceneStyle.image}
                    alt={scene.name.name}
                    className="h-15 w-15 object-contain"
                />

            </div>

            <div className="divider w-full my-2"></div>

            {/* Scene Description */}
            <div className="flex flex-col items-center">


                <div className="text-xs text-center text-custom-background p-5">
                    {scene.description.description}
                </div>
            </div>


            {/* SCENE DATA */}
            {scene instanceof ItemScene ? (
                <div className="flex flex-row items-center justify-center text-center gap-2 ">
                    <ItemSceneCard item={scene.rewardItem} />

                    {CharacterInScene ? (<div className="flex flex-col gap-2">
                        <button
                            className="btn btn-secondary"
                            disabled={!sceneItemExist}
                            onClick={() => useSceneItem(scene)}
                        >
                            Use Scene Item
                        </button>

                        <button
                            className="btn btn-secondary"
                            disabled={!sceneItemExist}
                            onClick={() => getSceneItem(scene)}
                        >
                            Get Scene Item
                        </button>
                    </div>) : null}


                </div>
            ) : null}


            {scene instanceof EnemyScene ? (
                <div className="flex flex-row items-center justify-center text-center gap-4 ">
                    <EnemySceneCard enemy={scene.enemy} currentEnemyHp={currentEnemyHp} enemyIsDead={enemyIsDead} />

                    {CharacterInScene ? (<div className="flex flex-col gap-2">
                        <button
                            className="btn btn-secondary"
                            disabled={!canAttackWithoutItem || enemyIsDead}
                            onClick={attackWithoutItem}
                        >
                            Attack without item
                        </button>
                    </div>) : null}


                </div>
            ) : null}


            {scene instanceof TradeScene ? (

                CharacterInScene ?
                    (
                        <div className="flex flex-row items-start justify-center w-full gap-10 mt-4 text-custom-background">

                            {/* Player Inventory */}
                            <div className="flex flex-col max-w-70 border rounded-xl p-2 bg-custom-tertiary max-h-50 ">
                                <div className="flex items-center justify-center font-bold mb-2 gap-1">
                                    Player Inventory :
                                    <DollarSign className="w-4 h-4 text-custom-background" />
                                    {characterCurrentMoney}
                                </div>
                                <div className="flex flex-col gap-1 overflow-y-auto">
                                    {characterInventory?.map((item, index) => (
                                        <div key={index} className="flex flex-row items-center justify-between p-2 border rounded-lg">
                                            <span className="truncate flex-1">{item.name.name}</span>

                                            <span className="flex items-center gap-1 mx-2">
                                                <DollarSign className="w-3 h-3 text-custom-background" />
                                                {item.tradePrice}
                                            </span>

                                            <button className="btn btn-secondary btn-sm" onClick={() => sellItem(index)} >
                                                Sell
                                            </button>
                                        </div>
                                    ))}
                                </div>
                            </div>

                            {/* Merchant Inventory */}
                            <div className="flex flex-col max-w-70 border rounded-xl p-2 bg-custom-tertiary max-h-50">
                                <div className="flex items-center justify-center font-bold mb-2 gap-1">
                                    Merchant Inventory :
                                    <DollarSign className="w-4 h-4 text-custom-background" />
                                    {scene.merchantMoneyToSpent}
                                </div>

                                <div className="flex flex-col gap-1 overflow-y-auto relative group">
                                    {scene.merchantItemsOffer.map((item, index) => {
                                        const priceWithMargin = (item.tradePrice ?? 0) + scene.profitMerchantMargin;
                                        return (
                                            <div key={index} className="flex flex-row items-center justify-between p-2 border rounded-lg">

                                                <span className="truncate flex-1">{item.name.name}</span>

                                                <span className="flex items-center gap-1 mx-2">
                                                    <DollarSign className="w-3 h-3 text-custom-background" />
                                                    {priceWithMargin}
                                                </span>

                                                <button className="btn btn-primary btn-sm" onClick={() => buyItem(index)}>
                                                    Buy
                                                </button>
                                            </div>
                                        );
                                    })}
                                </div>

                            </div>

                        </div>

                    ) : (
                        <div className="flex flex-col max-w-70 border rounded-xl p-2 bg-custom-tertiary max-h-50">
                            <div className="flex items-center justify-center font-bold mb-2 gap-1">
                                Merchant Inventory :
                                <DollarSign className="w-4 h-4 text-custom-background" />
                                {scene.merchantMoneyToSpent}
                            </div>

                            <div className="flex flex-col gap-1 overflow-y-auto relative group">
                                {scene.merchantItemsOffer.map((item, index) => {
                                    const priceWithMargin = (item.tradePrice ?? 0) + scene.profitMerchantMargin;
                                    return (
                                        <div key={index} className="flex flex-row items-center justify-between p-2 border rounded-lg">

                                            <span className="truncate flex-1">{item.name.name}</span>

                                            <span className="flex items-center gap-1 mx-2">
                                                <DollarSign className="w-3 h-3 text-custom-background" />
                                                {priceWithMargin}
                                            </span>
                                        </div>
                                    );
                                })}
                            </div>


                        </div>
                    )


            ) : null}




            {/* Move Forward */}
            <div className="flex flex-col items-center">
                {CharacterInScene ?
                    <button
                        className="btn btn-primary mt-4"
                        disabled={!canMoveForward}
                        onClick={() => getMoveForwardSceneId(scene.id)}
                    >
                        Move forward
                    </button> :
                    <button
                        className="btn btn-secondary mt-4"
                        disabled={!canMoveForward}
                        onClick={() => getMoveForwardSceneId(scene.id)}
                    >
                        Select scene
                    </button>}


            </div>



        </div>
    );

};
