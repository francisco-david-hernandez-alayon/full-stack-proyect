import type React from "react";
import { ItemScene } from "../../../../domain/entities/scenes/item-scene";
import { Scene } from "../../../../domain/entities/scenes/scene";
import { getStyleForBiome } from "../../utils/GetBiomeStyle";
import { getStyleForScene } from "../../utils/GetSceneStyle";
import { ItemToolTip } from "../Game/ItemToolTip";
import type { Item } from "../../../../domain/entities/items/item";
import { Enemy } from "../../../../domain/entities/enemy";
import { EnemyScene } from "../../../../domain/entities/scenes/enemy-scene";
import { ActivityIcon, AlertCircle, DiamondPlusIcon, DollarSign, Hand, Heart, Skull, Sword } from "lucide-react";
import { TradeScene } from "../../../../domain/entities/scenes/trade-scene";
import { RenderItemIcon } from "../Structure/RenderItemIcon";
import { getItemRarityColor } from "../../utils/getItemRarityColor";
import { getEnemyDifficultyColor } from "../../utils/getEnemyDifficultyColor";
import { RenderEnemyIcon } from "../Structure/RenderEnemyIcon";
import { useRef, useState } from "react";

interface itemSceneCardProps {
    item: Item
}

const ItemSceneCard: React.FC<itemSceneCardProps> = ({ item }) => {
    // ItemToolTip
    const slotRef = useRef<HTMLDivElement>(null);
    const [showTooltip, setShowTooltip] = useState(false);
    const [tooltipPos, setTooltipPos] = useState({ top: 0, left: 0 });

    const handleMouseEnter = () => {
        if (!slotRef.current) return;

        const rect = slotRef.current.getBoundingClientRect();

        setTooltipPos({
            top: rect.top - 8,
            left: rect.left + rect.width / 2,
        });

        setShowTooltip(true);
    };

    const handleMouseLeave = () => {
        setShowTooltip(false);
    };

    const rarityColorClass = getItemRarityColor(item.rarity);

    return (
        <div ref={slotRef} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave} className="flex flex-col gap-2 items-center justify-center border rounded-xl w-20 h-25">
            {showTooltip && (
                <ItemToolTip item={item} top={tooltipPos.top} left={tooltipPos.left} />
             )}

            <RenderItemIcon
                item={item}
                width={40}
                height={40}
            />


            <div className={`text-xs text-center text-custom-background ${rarityColorClass}`}>
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
    const difficultyColorClass = getEnemyDifficultyColor(enemy.difficulty);

    return (<div className="flex flex-col items-center bg-custom-background-soft justify-center border rounded-xl w-105 h-55">
        <div className={`text-xl text-custom-background ${difficultyColorClass}`}>
            {enemy.name.name}
        </div>

        <div className={`flex flex-row gap-4 items-center justify-center ${difficultyColorClass}`}>

            {/* IMAGE and HP */}
            <div className="flex flex-col items-center gap-3">
                <RenderEnemyIcon enemy={enemy} width={64} height={64}/>


                <div className="flex flex-row gap-1 items-center justify-center text-xl">
                    {enemyIsDead ? (
                        <Skull className="w-6 h-6" />
                    ) : (
                        <>
                            <span>{currentEnemyHp}/{enemy.healthPoints}</span>
                            <Heart className="w-6 h-6" />
                        </>
                    )}

                </div>
            </div>

            {/* Stats */}
            <div className={`flex flex-col gap-1 text-xm`}>

                <div className="flex items-center gap-2" >
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




interface MerchantItemRowProps {
    item: Item;
    price: number;
    onBuy?: () => void;
}

export const MerchantItemRow: React.FC<MerchantItemRowProps> = ({ item, price, onBuy }) => {
    const rowRef = useRef<HTMLDivElement>(null);
    const [showTooltip, setShowTooltip] = useState(false);
    const [tooltipPos, setTooltipPos] = useState({ top: 0, left: 0 });

    const handleMouseEnter = () => {
        if (!rowRef.current) return;

        const rect = rowRef.current.getBoundingClientRect();

        setTooltipPos({
            top: rect.top + rect.height / 2 + 120,
            left: rect.right + 120,
        });

        setShowTooltip(true);
    };

    const handleMouseLeave = () => {
        setShowTooltip(false);
    };

    return (
        <>
            {showTooltip && (
                <ItemToolTip
                    item={item}
                    top={tooltipPos.top}
                    left={tooltipPos.left}
                />
            )}

            <div
                ref={rowRef}
                onMouseEnter={handleMouseEnter}
                onMouseLeave={handleMouseLeave}
                className="flex flex-row items-center justify-between
                           p-2 border rounded-lg
                           hover:bg-custom-background/20 transition"
            >
                <span className={`truncate flex-1 ${getItemRarityColor(item.rarity)}`}>
                    {item.name.name}
                </span>

                <span className="flex items-center gap-1 mx-2">
                    <DollarSign className="w-3 h-3 text-custom-background" />
                    {price}
                </span>

                {onBuy ? (
                    <button className="btn btn-primary btn-sm" onClick={onBuy}>
                        Buy
                    </button>
                ) : null}
                
            </div>
        </>
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
            className="flex flex-col items-center justify-start p-2 rounded-2xl text-custom-background font-semibold w-full h-full max-w-3xl"
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
                                            <span className={`truncate flex-1 ${getItemRarityColor(item.rarity)}`}>{item.name.name}</span>

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

                                <div className="flex flex-col gap-1 overflow-y-auto">
                                    {scene.merchantItemsOffer.map((item, index) => {
                                        const priceWithMargin = (item.tradePrice ?? 0) + scene.profitMerchantMargin;

                                        return (
                                            <MerchantItemRow  key={index} item={item} price={priceWithMargin} onBuy={() => buyItem(index)} />
                                        );
                                    })}

                                </div>

                            </div>

                        </div>

                    ) : (
                        <div className="flex flex-col gap-1 overflow-y-auto">
                            {scene.merchantItemsOffer.map((item, index) => {
                                const priceWithMargin = (item.tradePrice ?? 0) + scene.profitMerchantMargin;

                                return (
                                    <MerchantItemRow
                                        key={index}
                                        item={item}
                                        price={priceWithMargin}
                                    />
                                );
                            })}
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
