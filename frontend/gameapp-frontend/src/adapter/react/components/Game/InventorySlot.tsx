import type React from "react";
import type { Item } from "../../../../domain/entities/items/item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import { ItemToolTip } from "./ItemToolTip";
import { Trash2 } from "lucide-react";
import { RenderItemIcon } from "../Structure/RenderItemIcon";
import { getItemRarityColor } from "../../utils/getItemRarityColor";
import { useRef, useState } from "react";

interface InventorySlotProps {
    item?: Item;
    useItem: () => void;
    dropItem: () => void;
}


export const InventorySlot: React.FC<InventorySlotProps> = ({ item, useItem, dropItem }) => {
    // ItemToolTip
    const slotRef = useRef<HTMLDivElement>(null);
    const [showTooltip, setShowTooltip] = useState(false);
    const [tooltipPos, setTooltipPos] = useState({ top: 0, left: 0 });

    const handleMouseEnter = () => {
        if (!slotRef.current) return;

        const rect = slotRef.current.getBoundingClientRect();

        setTooltipPos({
            top: rect.top - 8,
            left: rect.left + rect.width / 2,
        });

        setShowTooltip(true);
    };

    const handleMouseLeave = () => {
        setShowTooltip(false);
    };


    // EMPTY SLOT
    if (!item) {
        return (
            <div
                className="flex items-center justify-center
                           border rounded-lg
                           min-w-35 min-h-40
                           bg-custom-background opacity-50"
                style={{ borderColor: "var(--color-secondary)" }}
            />
        );
    }

    // ITEM SLOT
    const rarityColorClass = getItemRarityColor(item.rarity);

    return (
            <div ref={slotRef} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}
                className="flex flex-col items-center justify-between
                           border rounded-xl
                           w-35 h-40 p-2
                           bg-custom-background"
            >
                {/* Tooltip */}
                {showTooltip && (
                    <ItemToolTip item={item} top={tooltipPos.top} left={tooltipPos.left} />
                )}
                
                {/* Item icon */}
                <RenderItemIcon item={item} width={56} height={56} />

                {/* Item name */}
                <span className={`text-center leading-tight text-custom-secondary ${rarityColorClass}`}>
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
    );
};



