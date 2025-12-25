import type { Item } from "../../../domain/entities/items/item";


// Map each item type (class) to its base image
const getItemStyle: Record<
  string,
  { image: string }
> = {
  AttackItem: {
    image: "/images/items/espada.png",
  },
  AttributeItem: {
    image: "/images/items/pocion.png",
  },
};

export enum ItemImageColor {
  BLACK = "black",
  WHITE = "white",
}

export const getStyleForItem = (item: Item, color: ItemImageColor = ItemImageColor.BLACK) => {
  const baseStyle = getItemStyle[item.constructor.name];

  if (!baseStyle) {
    return { image: "" };
  }

  if (color === ItemImageColor.WHITE) {
    const imageWithWhiteSuffix = baseStyle.image.replace(
      ".png",
      "_blanco.png"
    );

    return {
      ...baseStyle,
      image: imageWithWhiteSuffix,
    };
  }

  return baseStyle;
};
