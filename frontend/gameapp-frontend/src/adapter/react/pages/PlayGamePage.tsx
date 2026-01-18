import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Game } from "../../../domain/entities/game";
import { GameHttpRepository } from "../../http/repository/game-http-repository";
import type { AlertData } from "../App";
import { AlertTimeMessage, AlertType } from "../components/Structure/AlertMessage";
import { ActivityIcon, Backpack, DollarSign, Ham, Heart, Sword, User } from "lucide-react";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { getStyleForCharacter } from "../utils/GetCharacterStyle";
import { SceneCard } from "../components/Cards/SceneCard";
import { GameAdvanceSceneService } from "../../../application/services/game-services/game-advance-scene-service";
import { GameUpdateService } from "../../../application/services/game-services/game-update-service";
import { GameGetService } from "../../../application/services/game-services/game-get-service";
import { GameStatus } from "../../../domain/enumerates/game-status";
import { InventorySlot } from "../components/Game/InventorySlot";
import { GameUseItemService } from "../../../application/services/game-services/game-use-item-service";
import { getLabelForUserAction } from "../utils/GetUserAction";
import type { Scene } from "../../../domain/entities/scenes/scene";
import { ItemScene } from "../../../domain/entities/scenes/item-scene";
import { GameManageItemService } from "../../../application/services/game-services/game-manage-item-service";
import { UserAction } from "../../../domain/enumerates/user-action";
import { EnemyScene } from "../../../domain/entities/scenes/enemy-scene";
import { GameSummary } from "../components/Game/GameSummary";
import { GameTradeService } from "../../../application/services/game-services/game-trade-service";
import { GameUseCharacterAbilityService } from "../../../application/services/game-services/game-use-character-ability-service";
import { CharacterAbilityButton } from "../components/Game/CharacterAbilityButton";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { DamageAlertInfo } from "../components/Game/DamageAlertInfo";


interface PlayGamePageProps {
    showAlert: (data: AlertData) => void;

}

export interface DamageAlertData {
  userDamage: number;
  enemyDamage: number;
}


export const PlayGamePage: React.FC<PlayGamePageProps> = ({ showAlert }) => {
    // ALERT DAMAGE
    const [damageAlert, setDamageAlert] = useState<DamageAlertData | null>(null);


    const { id } = useParams<{ id: string }>(); // get url id
    const [game, setGame] = useState<Game | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    const repoGames = new GameHttpRepository();
    const gameGetService = new GameGetService(repoGames);
    const gameAdvanceSceneService = new GameAdvanceSceneService(repoGames);
    const gameUpdateService = new GameUpdateService(repoGames);
    const gameUseItemService = new GameUseItemService();
    const gameManageItemService = new GameManageItemService();
    const gameTradeService = new GameTradeService();
    const gameUseCharacterAbilityService = new GameUseCharacterAbilityService();


    useEffect(() => {
        if (!id) return;

        const fetchGame = async () => {
            try {
                const fetchedGame = await gameGetService.getGame(id);
                setGame(fetchedGame);

            } catch (err) {
                setError(`Error fetching game with id ${id}`);
            } finally {
                setLoading(false);
            }
        };

        fetchGame();
    }, [id]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p className="text-custom-error">{error}</p>;
    if (!game) return <p>Game not found</p>;

    // STYLE
    const characterStyle = getStyleForCharacter(game.character);
    const healthPercent = (game.character.currentHealthPoints / game.character.maxHealthPoints) * 100;
    const foodPercent = (game.character.currentFoodPoints / game.character.maxFoodPoints) * 100;

    const getHpColorClass = (percent: number) => {
        if (percent <= 15) return "text-[var(--color-low-hp)]";
        if (percent <= 50) return "text-[var(--color-medium-hp)]";
        return "";
    };



    //---------------------------------------------------------GAME-FUNCTIONS----------------------------------------------------------//
    const saveGame = async () => {
        try {
            const updatedGame = await gameUpdateService.updateGame(game.id, game.difficulty, game.character, game.numberScenesToFinish, game.finalScene, game.currentScenes, game.currentUserActions, game.completedScenes, game.status, game.currentEnemy);
            setGame(updatedGame);

            showAlert({
                message: "Game saved",
                type: AlertType.SUCCESS,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });

        } catch (error) {
            showAlert({
                message: "Error saving game: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    };

    const moveForwardScene = async (sceneId: string) => {
        try {
            const updatedGame = await gameAdvanceSceneService.advance(sceneId, game);
            setGame(updatedGame);

            if (game.status == GameStatus.GAME_WON) {
                showAlert({
                    message: "GAME WON",
                    type: AlertType.SUCCESS,
                    duration: AlertTimeMessage.MEDIUM_MESSAGE_DURATION,
                });
            }

        } catch (error) {
            showAlert({
                message: "Error moving forward: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }

    }

    //---------------------------------------------------------ITEM-FUNCTIONS----------------------------------------------------------//
    const useInventoryItem = async (positionItemSelected: number) => {
        try {
            // check if user attack enemy
            const userHpBeforeAttack = game.character.currentHealthPoints;
            const enemyHpBeforeAttack = game.currentEnemy?.healthPoints ?? 0;
            let attackEnemy = false;
            if (game.character.inventoryList[positionItemSelected] instanceof AttackItem && game.currentEnemy != null) {
                attackEnemy = true;
            }
            
            const updatedGame = await gameUseItemService.useInventoryItem(positionItemSelected, game);
            setGame(updatedGame);

            // Show attack result
            if (attackEnemy) {
                const userDamage = enemyHpBeforeAttack - (updatedGame.currentEnemy?.healthPoints ?? 0);
                const enemyDamage = userHpBeforeAttack - updatedGame.character.currentHealthPoints;
                setDamageAlert({ userDamage, enemyDamage });
            }


        } catch (error) {
            showAlert({
                message: "Error using item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    }

    const dropInventoryItem = async (positionItemSelected: number) => {
        try {
            const updatedGame = await gameManageItemService.dropItem(positionItemSelected, game);
            setGame(updatedGame);

        } catch (error) {
            showAlert({
                message: "Error dropping item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    }

    const useSceneItem = async (currentScene: Scene) => {
        try {
            if (currentScene instanceof ItemScene) {
                const updatedGame = await gameUseItemService.useSceneItem(currentScene.rewardItem, game);
                setGame(updatedGame);
            }


        } catch (error) {
            showAlert({
                message: "Error using scene item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    }

    const getSceneItem = async (currentScene: Scene) => {
        try {
            if (game.character.isInventoryFull()) {
                showAlert({
                    message: `Max inventory slots reached(${game.character.inventoryList.length}/${game.character.maxInventorySlots})`,
                    type: AlertType.WARNING,
                    duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
                });
                return;
            }

            if (currentScene instanceof ItemScene) {
                const updatedGame = await gameManageItemService.getItem(currentScene.rewardItem, game);
                setGame(updatedGame);
            }

        } catch (error) {
            showAlert({
                message: "Error getting scene item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }

    }

    //---------------------------------------------------------ATTACK FUNCTIONS--------------------------------------------------------//
    const attackWithoutItem = async () => {
        try {
            if (game.currentEnemy) {
                const userHpBeforeAttack = game.character.currentHealthPoints;
                const enemyHpBeforeAttack = game.currentEnemy?.healthPoints ?? 0;

                const updatedGame = await gameUseItemService.attackWithoutItem(game);
                setGame(updatedGame);

                // Show attack result
                const userDamage = enemyHpBeforeAttack - (updatedGame.currentEnemy?.healthPoints ?? 0);
                const enemyDamage = userHpBeforeAttack - updatedGame.character.currentHealthPoints;
                setDamageAlert({ userDamage, enemyDamage });

            }

        } catch (error) {
            showAlert({
                message: "Error attacking without item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }

    }

    //---------------------------------------------------------TRADE-FUNCTIONS----------------------------------------------------------//

    const sellItem = async (posItemCharacterInventory: number) => {
        try {
            const updatedGame = await gameTradeService.sellItems(posItemCharacterInventory, game);
            setGame(updatedGame);

        } catch (error) {
            showAlert({
                message: "Error selling item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    }

    const buyItem = async (posItemTraderInventory: number) => {
        try {
            const updatedGame = await gameTradeService.buyItems(posItemTraderInventory, game);
            setGame(updatedGame);

        } catch (error) {
            showAlert({
                message: "Error buying item: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }
    }

    //---------------------------------------------------------ABILITY-FUNCTIONS----------------------------------------------------------//

    const useCharacterAbility = async () => {
        try {
            const updatedGame = await gameUseCharacterAbilityService.useAbility(game);
            setGame(updatedGame);

            if (game.character instanceof WarriorCharacter && game.character.canUseAbility()) {
                const warriorDamage = WarriorCharacter.ABILITY_DAMAGE;
                setDamageAlert({ userDamage: warriorDamage, enemyDamage: 0 });
            }

        } catch (error) {
            showAlert({
                message: "Error attacking with ability: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }

    }






    //----------------------------------------------------------------------------HTML-------------------------------------------------------------------------------//



    if (game.status == GameStatus.PLAYER_DEATH) {
        saveGame();
        return <GameSummary game={game} />
    }

    if (game.status == GameStatus.GAME_WON) {
        saveGame();
        return <GameSummary game={game} />
    }

    return (
        <div className="flex flex-col align-center h-full">
            {/* Damage Alert */}
            {damageAlert && (
            <DamageAlertInfo
                key={Date.now()}  // force re-render if invoked consecutively
                userDamage={damageAlert.userDamage}
                enemyDamage={damageAlert.enemyDamage}
                onClose={() => setDamageAlert(null)}
                />
            )}


            {/* HEADER */}
            <div className="flex flex-row p-4 justify-between items-center h-20 bg-custom-secondary">
                <h1 className="text-custom-background">Difficulty: {game.difficulty}</h1>

                <div className="flex flex-row gap-1 text-sm text-custom-background">
                    {game.currentUserActions.map((action, index) => {
                        const isLast = index === game.currentUserActions.length - 1;
                        const isSecondLast = index === game.currentUserActions.length - 2;

                        return (
                            <span key={index}>
                                {getLabelForUserAction(action)}
                                {!isLast && (
                                    isSecondLast ? " or " : ", "
                                )}
                            </span>
                        );
                    })}
                </div>

                <div className="flex flex-row items-center gap-12">
                    <button className="btn btn-custom-primary" onClick={() => saveGame()}>
                        Save game
                    </button>

                    <h1 className="text-custom-background">{game.completedScenes.length}/{game.numberScenesToFinish} scenes completed</h1>
                </div>

            </div>

            {/* CURRENT SCENES */}
            <div className="flex flex-1  gap-12 p-10 bg-custom-background">
                {game.currentScenes.map((scene, index) => (
                    <div key={index} className="flex flex-1 justify-center">
                        <SceneCard CharacterInScene={game.currentScenes.length == 1} scene={scene} canMoveForward={game.currentEnemy == null} getMoveForwardSceneId={moveForwardScene}
                            sceneItemExist={game.currentUserActions.includes(UserAction.USE_CURRENT_SCENE_ITEM)} useSceneItem={useSceneItem} getSceneItem={getSceneItem}
                            canAttackWithoutItem={game.currentUserActions.includes(UserAction.ATTACK_ENEMY_WITHOUT_ITEM)} attackWithoutItem={attackWithoutItem}
                            currentEnemyHp={game.currentEnemy?.healthPoints} enemyIsDead={(scene instanceof EnemyScene) && (game.currentScenes.length === 1) && (game.currentEnemy == null)}
                            characterCurrentMoney={game.character.currentMoney} characterInventory={game.character.inventoryList} sellItem={sellItem} buyItem={buyItem} />
                    </div>
                ))}
            </div>


            {/* CHARACTER INFO */}
            <div className="flex flex-row items-center justify-between p-3 bg-custom-background-soft rounded-xl">

                {/* Character stats */}
                <div className="flex flex-row items-center gap-5 pl-10">

                    <img
                        src={characterStyle.image}
                        alt="character img"
                        className="h-20 w-20"
                    />

                    <div className="flex flex-col gap-2 justify-center">
                        <h2 className="card-title text-custom-primary text-2xl">
                            {game.character.name.name}
                        </h2>

                        <div className="flex flex-row flex-wrap gap-5 text-custom-secondary">
                            {/* Health */}
                            <div className={`flex items-center gap-1 text-lg ${getHpColorClass(healthPercent)}`}>
                                <Heart className="w-8 h-8" />
                                <span>
                                    {game.character.currentHealthPoints}/{game.character.maxHealthPoints}
                                </span>
                            </div>

                            {/* Food */}
                            <div className={`flex items-center gap-1 text-lg ${getHpColorClass(foodPercent)}`}>
                                <Ham className="w-8 h-8" />
                                <span>
                                    {game.character.currentFoodPoints}/{game.character.maxFoodPoints}
                                </span>
                            </div>


                            <div className="flex items-center gap-1 text-lg">
                                <DollarSign className="w-8 h-8" />
                                <span>{game.character.currentMoney}</span>
                            </div>

                            <div className="flex items-center gap-1 text-lg">
                                <Sword className="w-8 h-8" />
                                <span>{game.character.attackDamage}</span>
                            </div>

                            <div className="flex items-center gap-1 text-lg">
                                <ActivityIcon className="w-8 h-8" />
                                <span>{game.character.attackSpeed}</span>
                            </div>
                        </div>

                    </div>

                    {/* Character ability */}
                    <CharacterAbilityButton character={game.character} onUseAbility={useCharacterAbility} />
                </div>


                {/* Inventory */}
                <div className="flex items-center  gap-5 pr-10">
                    <div className="flex items-center gap-5 max-w-200 overflow-x-auto ">

                        {game.character.inventoryList.map((item, index) => (
                            <div key={index} className="flex justify-center">
                                <InventorySlot item={item} useItem={() => (useInventoryItem(index))} dropItem={() => (dropInventoryItem(index))} />
                            </div>
                        ))}

                        {Array.from({
                            length: game.character.maxInventorySlots - game.character.inventoryList.length,
                        }).map((_, index) => (
                            <InventorySlot key={`empty-${index}`} useItem={() => (console.log("There's no item to use"))} dropItem={() => (console.log("There's no item to drop"))} />
                        ))}
                    </div>

                    <Backpack className="w-20 h-20" />
                </div>

            </div>


        </div>
    );
};
