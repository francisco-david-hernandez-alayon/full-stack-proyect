import { useNavigate } from "react-router-dom";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { GameHttpRepository } from "../../http/repository/game-http-repository";
import { SceneHttpRepository } from "../../http/repository/scene-http-repository";
import type { AlertData } from "../App";
import { AlertTimeMessage, AlertType } from "./Structure/AlertMessage";
import { GameCreateService } from "../../../application/services/game-services/game-create-service";
import { UserAction } from "../../../domain/enumerates/user-action";
import { SceneGetService } from "../../../application/services/scene-services/scene-get-service";

interface CreateNewGameProps {
    showAlert: (data: AlertData) => void;
}


export const CreateNewGamePage: React.FC<CreateNewGameProps> = ({ showAlert }) => {
    const repoGames = new GameHttpRepository();
    const repoScenes = new SceneHttpRepository();
    const gameCreateService = new GameCreateService(repoGames);
    const sceneGetService = new SceneGetService(repoScenes);

    const navigate = useNavigate();

    const createNewGame = async () => {
        try {
            // Get random final scene(NothingHappensScene)
            const scenes = await sceneGetService.getAllScenes();

            const nothingHappensScenes = scenes.filter(
                (scene) => scene instanceof NothingHappensScene
            );

            if (nothingHappensScenes.length === 0) {
                throw new Error("Theres no NothingHappensScene avaible");
            }
            const randomIndex1 = Math.floor(Math.random() * nothingHappensScenes.length);
            const randomIndex2 = Math.floor(Math.random() * nothingHappensScenes.length);
            const randomFinalScene = nothingHappensScenes[randomIndex1];
            const randomCurrentScene= nothingHappensScenes[randomIndex2];


            const character = new WarriorCharacter();  // default

            const gameCreated = await gameCreateService.createGame(character, 10, randomFinalScene, [randomCurrentScene], [UserAction.MOVE_FORWARD, UserAction.USE_ITEM]);

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