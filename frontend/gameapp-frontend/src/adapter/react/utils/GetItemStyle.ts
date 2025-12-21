import type { Item } from "../../../domain/entities/items/item";


// Map each item type (class) to a color and an image
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


export const getStyleForItem = (item: Item) => {
  return getItemStyle[item.constructor.name];
};
