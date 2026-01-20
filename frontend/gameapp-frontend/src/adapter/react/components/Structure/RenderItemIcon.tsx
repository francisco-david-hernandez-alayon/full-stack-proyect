import type React from "react";
import { Sword, Apple, Swords, Axe, Pickaxe, Gavel, Hammer, Ham, Drumstick, Hop, Beer, LeafyGreen, Wheat, Cherry, Salad, Beef, Nut, Martini, Bean, Pen, HeartPlus, Cake, Stone, MousePointer } from "lucide-react";
import { Item } from "../../../../domain/entities/items/item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import { AttributeItem } from "../../../../domain/entities/items/attribute-item";
import { getItemRarityColor } from "../../utils/getItemRarityColor";
import { ItemIcon } from "../../../../domain/enumerates/item-icon";



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


    switch (item.icon) {
        case ItemIcon.SWORD:
            return <Sword className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.DOUBLESWORD:
            return <Swords className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.AXE:
            return <Axe className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.MACE:
            return <Gavel className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.HAMMER:
            return <Hammer className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.SPEAR:
            return <MousePointer className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.SCYTHE:
            return <Pickaxe className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.STICK:
            return <Pen className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.STONE:
            return <Stone className={`${colorClass}`} width={width} height={height} />;



        
        case ItemIcon.CAKE:
            return <Cake className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.HEALTH:
            return <HeartPlus className={`${colorClass}`} width={width} height={height} />;
            
        case ItemIcon.APPLE:
            return <Apple className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.BREAD:
            return <Bean className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.HAM:
            return <Ham className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.BEEF:
            return <Beef className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.ROTTENMEAT:
            return <Drumstick className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.FRUITS:
            return <Hop className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.CHERRY:
            return <Cherry className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.SALAD:
            return <Salad className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.NUT:
            return <Nut className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.SHEET:
            return <LeafyGreen className={`${colorClass}`} width={width} height={height} />;
        
        case ItemIcon.ROOT:
            return <Wheat className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.BEER:
            return <Beer className={`${colorClass}`} width={width} height={height} />;

        case ItemIcon.CUP:
            return <Martini className={`${colorClass}`} width={width} height={height} />;

        default:
            break;
    }

    return null;
};
