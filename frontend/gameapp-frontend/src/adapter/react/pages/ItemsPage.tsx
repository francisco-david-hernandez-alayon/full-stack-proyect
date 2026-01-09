import { useEffect, useState } from "react";
import type { Item } from "../../../domain/entities/items/item";
import { ItemHttpRepository } from "../../http/repository/item-http-repository";
import { ItemType } from "../../../application/enumerates/item-type";
import type { AlertData } from "../App";
import { ItemCard } from "../components/Cards/ItemCard";
import { ItemGetService } from "../../../application/services/item-services/item-get-service";
import { AlertTimeMessage, AlertType } from "../components/Structure/AlertMessage";
import { ItemRarity } from "../../../domain/enumerates/item-rarity";

interface ItemsPageProps {
  showAlert: (data: AlertData) => void;
}

export const ItemsPage: React.FC<ItemsPageProps> = ({ showAlert }) => {
  const [itemTypeToSearch, setItemTypeToSearch] = useState<ItemType | undefined>(undefined);
  const [itemRarityToSearch, setItemRarityToSearch] = useState<ItemRarity | undefined>(undefined);
  const [items, setItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // Get all enemies when the component is mounted
  useEffect(() => {
    const repoItems = new ItemHttpRepository();
    const itemGetService = new ItemGetService(repoItems);

    const fetchItems = async () => {
      setLoading(true);
      setError(null);

      try {
        const allItems = await itemGetService.getItemByFilter(itemTypeToSearch, itemRarityToSearch);

        setItems(allItems);
      } catch (err) {
        const message = err instanceof Error ? err.message : "Unknown error";

        setError(message);
        showAlert({
          message: "Error fetching items: " + message,
          type: AlertType.ERROR,
          duration: AlertTimeMessage.SHORT_MESSAGE_DURATION,
        });
      } finally {
        setLoading(false);
      }
    };

    fetchItems();
  }, [itemTypeToSearch, itemRarityToSearch]);


  if (loading) {
    return <div> <span className="loading loading-spinner loading-xs"></span> <div className="p-6">Loading items...</div></div>;
  }

  if (error) {
    return <div className="p-6 text-error">{error}</div>;
  }

  return (
    <div className="flex flex-col align-center p-6">
      <h1 className="text-custom-primary-title">
        Items
      </h1>


      {/* FILTERS */}
      <div className="flex flex-row align-center justify-center items-center gap-5">
        {/* Type filter */}
        <div className="flex justify-center">
          <div className="join">
            <button
              className={`btn join-item ${itemTypeToSearch === undefined ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemTypeToSearch(undefined)}
            >
              All Types
            </button>

            <button
              className={`btn join-item ${itemTypeToSearch === ItemType.Attack ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemTypeToSearch(ItemType.Attack)}
            >
              Attack
            </button>

            <button
              className={`btn join-item ${itemTypeToSearch === ItemType.Attribute ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemTypeToSearch(ItemType.Attribute)}
            >
              Attribute
            </button>
          </div>
        </div>

        {/* Rarity filter */}
        <div className="flex justify-center">
          <div className="join">
            <button
              className={`btn join-item ${itemRarityToSearch === undefined ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemRarityToSearch(undefined)}
            >
              All rarities
            </button>

            <button
              className={`btn join-item ${itemRarityToSearch === ItemRarity.Common ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemRarityToSearch(ItemRarity.Common)}
            >
              Common
            </button>

            <button
              className={`btn join-item ${itemRarityToSearch === ItemRarity.Rare ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemRarityToSearch(ItemRarity.Rare)}
            >
              Rare
            </button>

            <button
              className={`btn join-item ${itemRarityToSearch === ItemRarity.Epic ? "btn-primary" : "btn-outline"}`}
              onClick={() => setItemRarityToSearch(ItemRarity.Epic)}
            >
              Epic
            </button>
          </div>
        </div>
      </div>


      {/* ITEMS */}
      <div className="grid grid-cols-2 md:grid-cols-3 gap-4">
        {items.map((item) => (
          <ItemCard key={item.id} item={item} />
        ))}
      </div>

    </div>
  );
};