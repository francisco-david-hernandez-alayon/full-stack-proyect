import type React from "react";
import { Activity, BookOpenTextIcon, DollarSign, Ham, Heart, HeartPlus, Stone, Sword, } from "lucide-react";
import type { Item } from "../../../domain/entities/items/item";
import { AttackItem } from "../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../domain/entities/items/attribute-item";

interface ItemCardProps {
    item: Item;
}

const renderItemIcon = (item: Item) => {
    if (item instanceof AttackItem) {
        return (
            <img
                src="/images/items/espada.png"
                alt="Attack item"
                className="h-12 w-12"
            />
        );
    }

    if (item instanceof AttributeItem) {
        return (
            <img
                src="/images/items/pocion.png"
                alt="Attribute item"
                className="h-12 w-12"
            />
        );
    }

    return null;
};

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
                    <Activity className="w-5 h-5 text-custom-secondary" />
                    <span>Attack Speed: {item.speedAttack}</span>
                </div>
                <div className="flex items-center gap-2">
                    <Stone className="w-5 h-5 text-custom-secondary" />
                    <span>Durability: {item.durability}</span>
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
    return (
        <div className="flex flex-row card bg-background shadow-md p-4 max-w-xl">
            <div className="flex flex-col items-center justify-center p-2 w-24 flex-none">
                {renderItemIcon(item)}

                <h2 className="card-title text-primary text-center mt-2">
                    {item.name.name}
                </h2>
            </div>

            <div className="divider lg:divider-horizontal"></div>

            <div className="flex-1 p-2">
                {renderItemDescription(item)}
            </div>
        </div>
    );
};