import { ActivityIcon, DiamondPlusIcon, DollarSign, Gem, Ham, HeartPlus, Stone, Sword } from "lucide-react";
import { AttributeItem } from "../../../../domain/entities/items/attribute-item";
import { AttackItem } from "../../../../domain/entities/items/attack-item";
import type { Item } from "../../../../domain/entities/items/item";
import { getItemRarityColor } from "../../utils/getItemRarityColor";

// INCLUDE ON PARENT
/*
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


<div ref={slotRef} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
{showTooltip && (
                <ItemToolTip item={item} top={tooltipPos.top} left={tooltipPos.left} />
            )}
</div>
*/


const formatPoints = (value: number): string => {
    if (value > 0) return `+${value}`;
    if (value < 0) return `${value}`;
    return '0';
};


const renderItemTooltipContent = (item: Item) => {
    const rarityColorClass = getItemRarityColor(item.rarity);

    if (item instanceof AttackItem) {
        return (
            <div className="flex flex-col gap-1">
                <div className="flex items-center gap-2">
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

                {item.foodPointsReceived != 0 && (
                    <div className="flex items-center gap-2">
                        <Ham className="w-4 h-4 text-custom-secondary" />
                        <span>Food: {formatPoints(item.foodPointsReceived)}</span>
                    </div>
                )}

                {item.healthPointsReceived != 0 && (
                    <div className="flex items-center gap-2">
                        <HeartPlus className="w-4 h-4 text-custom-secondary" />
                        <span>Health: {formatPoints(item.healthPointsReceived)}</span>
                    </div>
                )}


            </div>
        );
    }

    return null;
};

interface ItemToolTipProps {
    item: Item;
    top: number;
    left: number;
}


import { createPortal } from "react-dom";

export const ItemToolTip: React.FC<ItemToolTipProps> = ({ item, top, left }) => {
    return createPortal(
        <div
            className="fixed z-[9999]
                       w-52 p-3 rounded-lg shadow-lg
                       bg-custom-background text-custom-secondary
                       border border-custom-secondary
                       pointer-events-none"
            style={{
                top,
                left,
                transform: "translate(-50%, -100%)",
            }}
        >
            <div className="flex flex-col gap-2 text-sm">
                <span className="font-semibold text-base">
                    {item.name.name}
                    <span>Icon: {item.icon}</span>
                </span>
                
                {renderItemTooltipContent(item)}

            </div>
        </div>,
        document.body
    );
};


