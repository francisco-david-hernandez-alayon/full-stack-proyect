import type React from "react";
import { ActivityIcon, BookOpenTextIcon, DiamondPlusIcon, DollarSign, Ham, HeartPlus, Stone, Sword, } from "lucide-react";
import { Item } from "../../../../domain/entities/items/item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../../domain/entities/items/attribute-item";
import { RenderItemIcon } from "../Structure/RenderItemIcon";
import { getItemRarityColor } from "../../utils/getItemRarityColor";

interface ItemCardProps {
    item: Item;
}


const renderItemDescription = (item: Item) => {
    if (item instanceof AttackItem) {
        return (
            <div className="flex flex-col">
                <div className="flex items-center gap-2">
                    <BookOpenTextIcon className="w-5 h-5 text-custom-secondary" />
                    <span>Description: {item.description.description}</span>
                </div>

                <div className="flex items-center gap-2">
                    <DollarSign className="w-5 h-5 text-custom-secondary" />
                    <span>Trade Price: {item.tradePrice}</span>
                </div>
                <div className="flex items-center gap-2">
                    <Sword className="w-5 h-5 text-custom-secondary" />
                    <span>Attack Damage: {item.attackDamage}</span>
                </div>
                <div className="flex items-center gap-2">
                    <ActivityIcon className="w-5 h-5 text-custom-secondary" />
                    <span>Attack Speed: {item.speedAttack}</span>
                </div>
                <div className="flex items-center gap-2">
                    <Stone className="w-5 h-5 text-custom-secondary" />
                    <span>Durability: {item.durability}</span>
                </div>
                <div className="flex items-center gap-2">
                    <DiamondPlusIcon className="w-5 h-5 text-custom-secondary" />
                    <span>{item.criticalDamage.criticalProbability}% of {item.criticalDamage.extraDamage} extra damage</span>
                </div>
            </div>
        );
    }

    if (item instanceof AttributeItem) {
        return (
            <div className="flex flex-col">
                <div className="flex items-center gap-2">
                    <BookOpenTextIcon className="w-5 h-5 text-custom-secondary" />
                    <span>Description: {item.description.description}</span>
                </div>

                <div className="flex items-center gap-2">
                    <DollarSign className="w-5 h-5 text-custom-secondary" />
                    <span>Trade Price: {item.tradePrice}</span>
                </div>
                <div className="flex items-center gap-2">
                    <Ham className="w-5 h-5 text-custom-secondary" />
                    <span>{item.foodPointsReceived}</span>
                </div>
                <div className="flex items-center gap-2">
                    <HeartPlus className="w-5 h-5 text-custom-secondary" />
                    <span>{item.healthPointsReceived}</span>
                </div>
            </div>
        );
    }

    return null;
};



export const ItemCard: React.FC<ItemCardProps> = ({ item }) => {
    const rarityColorClass = getItemRarityColor(item.rarity);

    return (
        <div className="flex flex-row card bg-background shadow-md p-4 max-w-xl">
            <div className="flex flex-col items-center justify-center p-2 w-24 flex-none">
                
                <h2 className={`card-title text-center mt-2 ${rarityColorClass}`} >
                    {item.name.name}
                </h2>

                <RenderItemIcon item={item} width={48} height={48} />

                <h2 className={`text-center mt-2 font-semibold ${rarityColorClass}`} >
                    {item.rarity}
                </h2>

            </div>

            <div className="divider lg:divider-horizontal"></div>

            <div className="flex-1 p-2">
                {renderItemDescription(item)}
            </div>
        </div>
    );
};