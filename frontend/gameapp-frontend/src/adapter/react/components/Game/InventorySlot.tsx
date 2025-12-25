import type React from "react";
import type { Item } from "../../../../domain/entities/items/item";
import { getStyleForItem } from "../../utils/GetItemStyle";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import { ItemToolTip } from "./ItemToolTip";
import { Trash2 } from "lucide-react";

interface InventorySlotProps {
    item?: Item;
    useItem: () => void;
    dropItem: () => void;
}


export const InventorySlot: React.FC<InventorySlotProps> = ({ item, useItem, dropItem }) => {
    // EMPTY SLOT
    if (!item) {
        return (
            <div
                className="flex items-center justify-center
                           border rounded-lg
                           w-35 h-35
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
            <ItemToolTip item={item} />

            {/* Slot */}
            <div
                className="flex flex-col items-center justify-between
               border rounded-xl
               w-35 h-35
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
                <span className="text-center leading-tight text-custom-secondary">
                    {item.name.name}
                </span>

                {/* Action */}
                <div className="flex items-center gap-2 w-full">
                    {/* Use Item Button */}
                    <button
                        className="btn btn-primary btn-xs flex-1"
                        onClick={useItem}
                    >
                        Use {item instanceof AttackItem ? `(${item.durability})` : ""}
                    </button>

                    {/* Drop Item Button */}
                    <button
                        className="btn btn-secondary btn-xs w-7 flex justify-center items-center"
                        onClick={dropItem}
                    >
                        <Trash2 className="w-6 h-6" />
                    </button>
                </div>



            </div>

        </div>
    );
};


