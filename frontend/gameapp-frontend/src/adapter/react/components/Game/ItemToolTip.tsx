import { ActivityIcon, BookOpenTextIcon, DiamondPlusIcon, DollarSign, Gem, Ham, HeartPlus, Stone, Sword } from "lucide-react";
import { AttributeItem } from "../../../../domain/entities/items/attribute-item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import type { Item } from "../../../../domain/entities/items/item";
import { getItemRarityColor } from "../../utils/getItemRarityColor";

// MUST INCLUDE "relative group" in className when you gonna use it



const renderItemTooltipContent = (item: Item) => {
    const rarityColorClass = getItemRarityColor(item.rarity);

    if (item instanceof AttackItem) {
        return (
            <div className="flex flex-col gap-1">
                <div className="flex items-center gap-2">
                    <BookOpenTextIcon className="w-4 h-4 text-custom-secondary" />
                    <span>{item.description.description}</span>
                </div>

                <div className={`flex items-center gap-2 ${rarityColorClass}`}>
                    <Gem className={`w-4 h-4`} />
                    <span>Rarity: {item.rarity}</span>
                </div>

                <div className="flex items-center gap-2">
                    <DollarSign className="w-4 h-4 text-custom-secondary" />
                    <span>Price: {item.tradePrice}</span>
                </div>

                <div className="flex items-center gap-2">
                    <Sword className="w-4 h-4 text-custom-secondary" />
                    <span>Damage: {item.attackDamage}</span>
                </div>

                <div className="flex items-center gap-2">
                    <ActivityIcon className="w-4 h-4 text-custom-secondary" />
                    <span>Speed: {item.speedAttack}</span>
                </div>

                <div className="flex items-center gap-2">
                    <Stone className="w-4 h-4 text-custom-secondary" />
                    <span>Durability: {item.durability}</span>
                </div>

                <div className="flex items-center gap-2">
                    <DiamondPlusIcon className="w-4 h-4 text-custom-secondary" />
                    <span>{item.criticalDamage.criticalProbability}% of {item.criticalDamage.extraDamage} extra damage</span>
                </div>
            </div>
        );
    }

    if (item instanceof AttributeItem) {
        return (
            <div className="flex flex-col gap-1">
                <div className="flex items-center gap-2">
                    <BookOpenTextIcon className="w-4 h-4 text-custom-secondary" />
                    <span>{item.description.description}</span>
                </div>

                <div className={`flex items-center gap-2 ${rarityColorClass}`}>
                    <Gem className={`w-4 h-4`} />
                    <span>Rarity: {item.rarity}</span>
                </div>

                <div className="flex items-center gap-2">
                    <DollarSign className="w-4 h-4 text-custom-secondary" />
                    <span>Price: {item.tradePrice}</span>
                </div>

                <div className="flex items-center gap-2">
                    <Ham className="w-4 h-4 text-custom-secondary" />
                    <span>Food: +{item.foodPointsReceived}</span>
                </div>

                <div className="flex items-center gap-2">
                    <HeartPlus className="w-4 h-4 text-custom-secondary" />
                    <span>Health: +{item.healthPointsReceived}</span>
                </div>
            </div>
        );
    }

    return null;
};

interface InventoryItemToolTipProps {
    item: Item;
}


export const ItemToolTip: React.FC<InventoryItemToolTipProps> = ({ item }) => {
    return (
        <div
            className="absolute bottom-full mb-2 hidden group-hover:flex 
                           w-52 p-3 rounded-lg shadow-lg
                           bg-custom-background text-custom-secondary
                           border border-custom-secondary
                           z-50"
        >
            <div className="flex flex-col gap-2 text-sm">
                <span className="font-semibold text-base">
                    {item.name.name}
                </span>

                {renderItemTooltipContent(item)}
            </div>
        </div>
    );
}