import { useEffect, useState } from "react";
import type { Item } from "../../../domain/entities/items/item";
import { ItemHttpRepository } from "../../http/repository/item-http-repository";
import { ItemCard } from "../components/ItemCard";
import { ItemType } from "../../../application/enumerates/item-type";

export const ItemsPage: React.FC = () => {
  const [itemTypeToSearch, setItemTypeToSearch] = useState<ItemType | null>(null);
  const [items, setItems] = useState<Item[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  // Get all enemies when the component is mounted
  useEffect(() => {
    const repoItems = new ItemHttpRepository();

    const fetchItems = async () => {
      try {
        let allItems: Item[] = [];
        if (itemTypeToSearch == null) {
          allItems = await repoItems.fetchAll();

        } else {
          allItems = await repoItems.fetchAllByType(itemTypeToSearch);
        }

        setItems(allItems);

      } catch (err) {
        setError("Error fetching items");

      } finally {
        setLoading(false);
      }
    };

    fetchItems();
  }, [itemTypeToSearch]);


  if (loading) {
    return <div> <span className="loading loading-spinner loading-xs"></span> <div className="p-6">Loading items...</div></div>;
  }

  if (error) {
    return <div className="p-6 text-error">{error}</div>;
  }

  return (
    <div className="p-6">
      <h1 className="text-custom-primary-title">
        Items
      </h1>

      <div className="flex justify-center p-6">
        <div className="join">
          <button
            className={`btn join-item ${itemTypeToSearch === null ? "btn-primary" : "btn-outline"
              }`}
            onClick={() => setItemTypeToSearch(null)}
          >
            All
          </button>

          <button
            className={`btn join-item ${itemTypeToSearch === ItemType.Attack ? "btn-primary" : "btn-outline"
              }`}
            onClick={() => setItemTypeToSearch(ItemType.Attack)}
          >
            Attack
          </button>

          <button
            className={`btn join-item ${itemTypeToSearch === ItemType.Attribute ? "btn-primary" : "btn-outline"
              }`}
            onClick={() => setItemTypeToSearch(ItemType.Attribute)}
          >
            Attribute
          </button>
        </div>
      </div>


      <div className="grid grid-cols-2 md:grid-cols-3 gap-4">
        {items.map((item) => (
          <ItemCard key={item.id} item={item} />
        ))}
      </div>

    </div>
  );
};