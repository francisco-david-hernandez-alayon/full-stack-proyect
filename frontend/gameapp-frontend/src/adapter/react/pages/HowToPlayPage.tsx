import { HeartPulse, Layers, Map, Skull, Swords, Target, Utensils } from "lucide-react";
import type { AlertData } from "../App";

interface HowToplayPageProps {
  showAlert: (data: AlertData) => void;
}

export const HowToPlayPage: React.FC<HowToplayPageProps> = ({ showAlert }) => {
    return (
        <div className="flex flex-col gap-10 p-6 max-w-4xl mx-auto">
            
            {/* Title */}
            <h1 className="text-3xl font-bold text-custom-primary-title">
                How to Play
            </h1>

            {/* Goal */}
            <section className="flex flex-col gap-2">
                <h2 className="flex items-center gap-2 text-xl font-semibold text-custom-primary">
                    <Target className="w-5 h-5" />
                    Winning Objective
                </h2>
                <p className="text-sm leading-relaxed">
                    The goal of the game is to progress through different scenes until reaching the final one,
                    while staying alive. You must avoid dying either from losing all your health or from starvation.
                </p>
                <p className="text-sm leading-relaxed">
                    Throughout the journey, you will collect items that can be used to heal, restore food,
                    sell for money, or fight enemies. When multiple scenes are available, you must choose
                    which one to advance to.
                </p>
            </section>

            {/* Biomes */}
            <section className="flex flex-col gap-2">
                <h2 className="flex items-center gap-2 text-xl font-semibold text-custom-primary">
                    <Map className="w-5 h-5" />
                    Biomes
                </h2>
                <p className="text-sm leading-relaxed">
                    The game features four different biomes, each with unique scenes and enemies.
                    While progressing through a biome, only scenes from that biome will appear,
                    unless a <strong>ChangeBiomeScene</strong> is triggered.
                </p>
                <p className="text-sm leading-relaxed">
                    Each biome has:
                </p>
                <ul className="list-disc list-inside text-sm">
                    <li>Unique enemies</li>
                    <li>Enemies shared with other biomes</li>
                    <li>A unique epic weapon</li>
                    <li>A unique boss that may appear randomly</li>
                </ul>
            </section>

            {/* Scene Types */}
            <section className="flex flex-col gap-2">
                <h2 className="flex items-center gap-2 text-xl font-semibold text-custom-primary">
                    <Layers className="w-5 h-5" />
                    Scene Types
                </h2>
                <ul className="list-disc list-inside text-sm leading-relaxed">
                    <li><strong>NothingHappensScene</strong>: Nothing significant happens.</li>
                    <li><strong>ChangeBiomeScene</strong>: Allows switching to a different biome.</li>
                    <li><strong>ItemScene</strong>: Lets you obtain an item if your inventory is not full.</li>
                    <li><strong>EnemyScene</strong>: You must defeat an enemy to proceed.</li>
                    <li><strong>TradeScene</strong>: Allows buying and selling items with a merchant, limited by the merchant’s money.</li>
                </ul>
                <p className="text-sm leading-relaxed">
                    Scene probabilities depend on the biome. Hard enemies do not appear before scene 11,
                    and boss enemies do not appear before scene 21.
                </p>
            </section>

            {/* Death Conditions */}
            <section className="flex flex-col gap-2">
                <h2 className="flex items-center gap-2 text-xl font-semibold text-custom-primary">
                    <Skull className="w-5 h-5" />
                    Ways to Die
                </h2>
                <ul className="list-disc list-inside text-sm">
                    <li className="flex items-center gap-2">
                        <HeartPulse className="w-4 h-4" />
                        <span>
                            <strong>Health</strong>: If an enemy reduces your health to zero, the game ends immediately.
                        </span>
                    </li>
                    <li className="flex items-center gap-2">
                        <Utensils className="w-4 h-4" />
                        <span>
                            <strong>Food</strong>: Advancing to a new scene consumes 5 food points. If food reaches zero, you die.
                        </span>
                    </li>
                </ul>
            </section>

            {/* Combat */}
            <section className="flex flex-col gap-2">
                <h2 className="flex items-center gap-2 text-xl font-semibold text-custom-primary">
                    <Swords className="w-5 h-5" />
                    Combat
                </h2>
                <p className="text-sm leading-relaxed">
                    When an <strong>EnemyScene</strong> starts, or when you select one among multiple scenes,
                    combat begins. The player can attack either unarmed or using a weapon item.
                </p>
                <ul className="list-disc list-inside text-sm">
                    <li><strong>Unarmed</strong>: Uses the character’s base damage and attack speed.</li>
                    <li><strong>With weapon</strong>: Weapon damage and speed are added to the character’s stats.</li>
                </ul>
                <p className="text-sm leading-relaxed">
                    Each time you attack, the enemy also attacks. The character with the higher speed
                    attacks first (ties favor the player). This becomes critical during the final hits
                    before killing or being killed.
                </p>
                <p className="text-sm leading-relaxed">
                    Defeating an enemy grants money, which can be used later when encountering a merchant.
                </p>
            </section>

        </div>
    );
};

