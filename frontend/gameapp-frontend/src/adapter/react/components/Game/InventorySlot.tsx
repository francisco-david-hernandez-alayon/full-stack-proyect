import type React from "react";
import type { Item } from "../../../../domain/entities/items/item";
import { getStyleForItem } from "../../utils/GetItemStyle";
import { ActivityIcon, BookOpenTextIcon, DollarSign, Ham, HeartPlus, Stone, Sword } from "lucide-react";
import { AttributeItem } from "../../../../domain/entities/items/attribute-item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";

interface InventorySlotProps {
    item?: Item;
    useItem: () => void;
}

const renderItemTooltipContent = (item: Item) => {
    if (item instanceof AttackItem) {
        return (
            <div className="flex flex-col gap-1">
                <div className="flex items-center gap-2">
                    <BookOpenTextIcon className="w-4 h-4 text-custom-secondary" />
                    <span>{item.description.description}</span>
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


export const InventorySlot: React.FC<InventorySlotProps> = ({ item, useItem }) => {
    // EMPTY SLOT
    if (!item) {
        return (
            <div
                className="flex items-center justify-center
                           border rounded-lg
                           w-20 h-24
                           bg-custom-background opacity-50"
                style={{ borderColor: "var(--color-secondary)" }}
            />
        );
    }

    // ITEM SLOT
    const itemStyle = getStyleForItem(item);

    return (
        <div className="relative group">
            {/* Tooltip */}
            <div
                className="absolute bottom-full mb-2 hidden group-hover:flex
                           w-52 p-3 rounded-lg shadow-lg
                           bg-custom-background text-custom-secondary
                           border border-custom-secondary
                           z-50"
            >
                <div className="flex flex-col gap-2 text-xs">
                    <span className="font-semibold text-sm">
                        {item.name.name}
                    </span>

                    {renderItemTooltipContent(item)}
                </div>
            </div>

            {/* Slot */}
            <div
                className="flex flex-col items-center justify-between
               border rounded-xl
               w-28 h-36
               p-2
               bg-custom-background
               hover:shadow-lg transition-shadow
               cursor-default"
                style={{ borderColor: "var(--color-secondary)" }}
            >

                {/* Item image */}
                <img
                    src={itemStyle.image}
                    alt={item.name.name}
                    className="h-14 w-14 object-contain"
                />

                {/* Item name */}
                <span className="text-center leading-tight text-custom-secondary text-xs font-medium">
                    {item.name.name}
                </span>

                {/* Action */}
                <button
                    className="btn btn-primary btn-xs w-full"
                    onClick={useItem}
                >
                    Use {item instanceof AttackItem ? `(${item.durability})` : ""}
                </button>

            </div>

        </div>
    );
};


