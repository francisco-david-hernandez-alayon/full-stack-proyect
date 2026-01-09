import { ItemRarity } from "../../../domain/enumerates/item-rarity";

export const getItemRarityColor = (rarity: ItemRarity): string => {
    switch (rarity) {
        case ItemRarity.Common:
            return "text-[var(--color-common-item)]";
        case ItemRarity.Rare:
            return "text-[var(--color-rare-item)]";
        case ItemRarity.Epic:
            return "text-[var(--color-epic-item)]";
        default:
            return "";
    }
};