import { useNavigate } from "react-router-dom";
import type { AlertData } from "../App";
import { GameHttpRepository } from "../../http/repository/game-http-repository";
import { SceneHttpRepository } from "../../http/repository/scene-http-repository";
import { GameCreateService } from "../../../application/services/game-services/game-create-service";
import { SceneGetService } from "../../../application/services/scene-services/scene-get-service";
import { NothingHappensScene } from "../../../domain/entities/scenes/nothing-happens-scene";
import { AlertTimeMessage, AlertType } from "../components/Structure/AlertMessage";
import { GameDifficulty } from "../../../domain/enumerates/game-difficulty";
import { UserAction } from "../../../domain/enumerates/user-action";
import { WarriorCharacter } from "../../../domain/value-objects/characters/warrior-character";
import { useState } from "react";
import { ActivityIcon, DollarSign, Heart, Sword } from "lucide-react";
import { getStyleForCharacter } from "../utils/GetCharacterStyle";
import type { Character } from "../../../domain/value-objects/characters/character";
import { ThiefCharacter } from "../../../domain/value-objects/characters/thief-caracter";
import { BerserkerCharacter } from "../../../domain/value-objects/characters/berserker-character";
import { ExplorerCharacter } from "../../../domain/value-objects/characters/explorer-character";


//-------------------------------------------------------------------------------SUMMARY-CHARACTER-CARD------------------------------------------------------------------------//

interface SummaryCardCharacterProps {
    character: Character;
    isSelected?: boolean;
    onSelect: (character: Character) => void;
}

export const SummaryCardCharacter: React.FC<SummaryCardCharacterProps> = ({ character, isSelected, onSelect }) => {
    const style = getStyleForCharacter(character);

    return (
        <div
            className={`card shadow-md bg-base-100 w-40 p-2 rounded-lg flex flex-col items-center gap-2 
      ${isSelected ? "border-2 border-primary" : ""}`}
        >
            {/* Image + Name */}
            <div className="flex flex-col items-center">
                <img src={style.image} alt={character.constructor.name} className="h-16 w-16 object-contain mb-1" />
                <h3 className="text-sm font-bold text-center truncate">{character.name.name}</h3>
            </div>

            {/* Stats */}
            <div className="flex flex-col gap-1 text-xs text-custom-secondary w-full">
                <div className="flex items-center justify-between">
                    <div className="flex items-center gap-1"><Heart className="w-3 h-3" /> HP</div>
                    <span>{character.maxHealthPoints}</span>
                </div>
                <div className="flex items-center justify-between">
                    <div className="flex items-center gap-1"><DollarSign className="w-3 h-3" /> Gold</div>
                    <span>{character.startingMoney}</span>
                </div>
                <div className="flex items-center justify-between">
                    <div className="flex items-center gap-1"><Sword className="w-3 h-3" /> Atk</div>
                    <span>{character.attackDamage}</span>
                </div>
                <div className="flex items-center justify-between">
                    <div className="flex items-center gap-1"><ActivityIcon className="w-3 h-3" /> Spd</div>
                    <span>{character.attackSpeed}</span>
                </div>
                <div className="flex items-center justify-between">
                    <div className="flex items-center gap-1 font-bold"> Hability: </div>
                    <span>{style.abilityName} </span>
                </div>
            </div>

            {/* Select Button */}
            <button
                className={`btn btn-sm w-full ${isSelected ? "btn-primary" : "btn-outline"}`}
                onClick={() => onSelect(character)}
            >
                {isSelected ? "Selected" : "Select"}
            </button>
        </div>
    );
};









//-------------------------------------------------------------------------------CREATE-GAME-PAGE------------------------------------------------------------------------//
interface CreateNewGamePageProps {
    showAlert: (data: AlertData) => void;
}


export const CreateNewGamePage: React.FC<CreateNewGamePageProps> = ({ showAlert }) => {
    const repoGames = new GameHttpRepository();
    const repoScenes = new SceneHttpRepository();
    const gameCreateService = new GameCreateService(repoGames);
    const sceneGetService = new SceneGetService(repoScenes);
    const navigate = useNavigate();

    // Local state
    const [selectedDifficulty, setSelectedDifficulty] = useState<GameDifficulty>(GameDifficulty.Normal);
    const [selectedRounds, setSelectedRounds] = useState<number>(60); // default "medio"
    const [selectedCharacter, setSelectedCharacter] = useState<Character>(new WarriorCharacter());  // warrior character is default initial character

    const roundOptions = [
        { label: "Short", value: 30 },
        { label: "Medium", value: 60 },
        { label: "Long", value: 90 },
    ];

    const difficultyOptions = [
        { label: "Easy", value: GameDifficulty.Easy },
        { label: "Normal", value: GameDifficulty.Normal },
        { label: "Hard", value: GameDifficulty.Hard },
    ];

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
            const randomInitialCurrentScene = nothingHappensScenes[randomIndex1];


            // Get final Scene
            const finalScenes = await sceneGetService.getAllFinalScenes();
            if (finalScenes.length === 0) {
                throw new Error("Theres no FinalScenes avaible");
            }
            const randomIndex2 = Math.floor(Math.random() * finalScenes.length);
            const randomFinalScene = finalScenes[randomIndex2];

            const gameCreated = await gameCreateService.createGame(
                selectedDifficulty,
                selectedCharacter,
                selectedRounds,
                randomFinalScene,
                [randomInitialCurrentScene],
                [UserAction.MOVE_FORWARD, UserAction.USE_ITEM]
            );

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
        <div className="flex flex-col items-center text-center justify-center gap-5 p-6">
            <h1 className="text-custom-primary-title text-2xl">Create new Game</h1>

            <div className="flex flex-col items-center text-center justify-center gap-5 border border-primary rounded-xl p-5">
                <h1 className="card-title font-bold mb-2">Select Options</h1>

                <div className="flex flex-row gap-10 ">
                    {/* Difficulty */}
                    <div>
                        <h2 className="font-bold mb-2">Difficulty</h2>
                        <div className="flex gap-4">
                            {difficultyOptions.map((option) => (
                                <button
                                    key={option.value}
                                    onClick={() => setSelectedDifficulty(option.value)}
                                    className={`btn ${selectedDifficulty === option.value ? "btn-primary" : "btn-outline"}`}
                                >
                                    {option.label}
                                </button>
                            ))}
                        </div>
                    </div>

                    {/* Rounds */}
                    <div>
                        <h2 className="font-bold mb-2">Rounds to survive to win</h2>
                        <div className="flex gap-4">
                            {roundOptions.map((option) => (
                                <button
                                    key={option.value}
                                    onClick={() => setSelectedRounds(option.value)}
                                    className={`btn ${selectedRounds === option.value ? "btn-primary" : "btn-outline"}`}
                                >
                                    {option.label} ({option.value})
                                </button>
                            ))}
                        </div>
                    </div>
                </div>

                {/* Character */}
                <div>
                    <h2 className="font-bold mb-2">Character</h2>
                    <div className="flex gap-10 justify-center">
                        <SummaryCardCharacter
                            character={new WarriorCharacter()}
                            isSelected={selectedCharacter?.constructor.name === "WarriorCharacter"}
                            onSelect={(char) => setSelectedCharacter(char)}
                        />

                        <SummaryCardCharacter
                            character={new ThiefCharacter()}
                            isSelected={selectedCharacter?.constructor.name === "ThiefCharacter"}
                            onSelect={(char) => setSelectedCharacter(char)}
                        />

                        <SummaryCardCharacter
                            character={new BerserkerCharacter()}
                            isSelected={selectedCharacter?.constructor.name === "BerserkerCharacter"}
                            onSelect={(char) => setSelectedCharacter(char)}
                        />

                        <SummaryCardCharacter
                            character={new ExplorerCharacter()}
                            isSelected={selectedCharacter?.constructor.name === "ExplorerCharacter"}
                            onSelect={(char) => setSelectedCharacter(char)}
                        />
                    </div>
                </div>


                {/* Start Game */}
                <div>
                    <button className="btn btn-primary" onClick={createNewGame}>
                        Start game
                    </button>
                </div>

            </div>

        </div>
    );
};