import { useNavigate } from "react-router-dom";
import { NothingHappensScene } from "../../../../domain/entities/scenes/nothing-happens-scene";
import { WarriorCharacter } from "../../../../domain/value-objects/characters/warrior-character";
import { GameHttpRepository } from "../../../http/repository/game-http-repository";
import { SceneHttpRepository } from "../../../http/repository/scene-http-repository";
import type { AlertData } from "../../App";
import { AlertTimeMessage, AlertType } from "../Structure/AlertMessage";
import { GameCreateService } from "../../../../application/services/game-services/game-create-service";
import { UserAction } from "../../../../domain/enumerates/user-action";
import { SceneGetService } from "../../../../application/services/scene-services/scene-get-service";

interface CreateNewGameProps {
    showAlert: (data: AlertData) => void;
}


export const CreateNewGamePage: React.FC<CreateNewGameProps> = ({ showAlert }) => {
    const repoGames = new GameHttpRepository();
    const repoScenes = new SceneHttpRepository();
    const gameCreateService = new GameCreateService(repoGames);
    const sceneGetService = new SceneGetService(repoScenes);
    const scenesToFinish = 5;

    const navigate = useNavigate();

    const createNewGame = async () => {
        try {
            // Get Initial Scene
            const scenes = await sceneGetService.getAllScenes();
            const nothingHappensScenes = scenes.filter(
                (scene) => scene instanceof NothingHappensScene
            );
            if (nothingHappensScenes.length === 0) {
                throw new Error("Theres no NothingHappensScene avaible");
            }
            const randomIndex1 = Math.floor(Math.random() * nothingHappensScenes.length);
            const randomInitialCurrentScene= nothingHappensScenes[randomIndex1];


            // Get final Scene
            const finalScenes = await sceneGetService.getAllFinalScenes();
            if (finalScenes.length === 0) {
                throw new Error("Theres no FinalScenes avaible");
            }
            const randomIndex2 = Math.floor(Math.random() * finalScenes.length);
            const randomFinalScene = finalScenes[randomIndex2];


            const character = new WarriorCharacter();  // default
            const gameCreated = await gameCreateService.createGame(character, scenesToFinish, randomFinalScene, [randomInitialCurrentScene], [UserAction.MOVE_FORWARD, UserAction.USE_ITEM]);

            navigate(`/play-game/${gameCreated.id}`)



        } catch (error) {
            showAlert({
                message: "Error creating new game: " + error,
                type: AlertType.ERROR,
                duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
            });
        }

    }

    return (
        <>
            <button className="btn btn-primary mt-4" onClick={() => createNewGame()}>
                Start new Game
            </button>
        </>
    );
};