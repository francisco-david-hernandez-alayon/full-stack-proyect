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
import { ActivityIcon, DollarSign, Heart, Skull, Sword } from "lucide-react";

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
    return (<div className="flex flex-col items-center justify-center border rounded-xl w-85 h-40">
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

                <div className="flex  gap-2">
                    <Sword className="w-4 h-4 " />
                    <span>Damage: {enemy.attackDamage}</span>
                </div>

                <div className="flex items-center gap-2">
                    <ActivityIcon className="w-4 h-4 " />
                    <span>Speed: {enemy.speedAttack}</span>
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
    sceneItemExist: boolean;
    useSceneItem: () => void;
    getSceneItem: () => void;

    // enemy
    canAttackWithoutItem: boolean;
    attackWithoutItem: () => void;
    currentEnemyHp?: number;
    enemyIsDead: boolean;

}

export const SceneCard: React.FC<SceneCardProps> = ({ CharacterInScene, scene, canMoveForward, getMoveForwardSceneId, sceneItemExist, useSceneItem, getSceneItem, canAttackWithoutItem, attackWithoutItem, currentEnemyHp, enemyIsDead }) => {
    const biomeStyle = getStyleForBiome(scene.biome);
    const sceneStyle = getStyleForScene(scene);

    return (
        <div
            className="flex flex-col items-center justify-start p-4 rounded-2xl text-white font-semibold w-full h-full max-w-3xl"
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
                            onClick={useSceneItem}
                        >
                            Use Scene Item
                        </button>

                        <button
                            className="btn btn-secondary"
                            disabled={!sceneItemExist}
                            onClick={getSceneItem}
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


            {/* Move Forward */}
            <div className="flex flex-col items-center">
                <button
                    className="btn btn-primary mt-4"
                    disabled={!canMoveForward}
                    onClick={() => getMoveForwardSceneId(scene.id)}
                >
                    Move forward
                </button>



            </div>



        </div>
    );

};
