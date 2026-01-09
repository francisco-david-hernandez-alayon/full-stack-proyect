import type React from "react";
import { Sword, Apple } from "lucide-react";
import { Item } from "../../../../domain/entities/items/item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../../domain/entities/items/attribute-item";
import { getItemRarityColor } from "../../utils/getItemRarityColor";



interface RenderItemIconProps {
    item: Item;
    width: number;
    height: number;
}

export const RenderItemIcon: React.FC<RenderItemIconProps> = ({
    item,
    width,
    height,
}) => {
    const colorClass = getItemRarityColor(item.rarity);

    if (item instanceof AttackItem) {
        return <Sword className={`${colorClass}`} width={width} height={height} />;
    }

    if (item instanceof AttributeItem) {
        return <Apple className={`${colorClass}`} width={width} height={height} />;
    }

    return null;
};
