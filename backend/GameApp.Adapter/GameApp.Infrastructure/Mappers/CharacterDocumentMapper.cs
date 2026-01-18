using GameApp.Domain.ValueObjects.Characters;
using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Items;
using GameApp.Domain.ValueObjects.Items;
using GameApp.Domain.Repositories;
using GameApp.Application.Enumerates;

namespace GameApp.Adapter.Infrastructure.Mappers;

public static class CharacterDocumentMapper
{
    public static CharacterDocument ToDocument(Character character)
    {
        // Get character atributes
        int? currentHits = null;
        int? currentKills = null;
        int? currentNothingHappensScenes = null;

        if (character is WarriorCharacter warrior)
        {
            currentHits = warrior.GetHits();
        }
        if (character is BerserkerCharacter berserker)
        {
            currentKills = berserker.GetKills();
        }
        if (character is ExplorerCharacter explorer)
        {
            currentNothingHappensScenes = explorer.GetNothingHappensScenesVisited();
        }


        return new CharacterDocument
        {
            Type = character switch
            {
                WarriorCharacter => CharacterType.Warrior,
                ThiefCharacter => CharacterType.Thief,
                BerserkerCharacter => CharacterType.Berserker,
                ExplorerCharacter => CharacterType.Explorer,
                _ => CharacterType.None
            },
            CurrentHealthPoints = character.GetCurrentHealthPoints(),
            CurrentFoodPoints = character.GetCurrentFoodPoints(),
            CurrentMoney = character.GetCurrentMoney(),

            // optional atributes
            CurrentHits = currentHits,
            CurrentKills = currentKills,
            CurrentNothingHappensScenes = currentNothingHappensScenes,

            // Map item name + durability
            InventoryList = character.GetInventoryList()
                .Select(item =>
                {
                    int durability =
                        item is AttackItem attack
                        ? attack.GetDurability()
                        : 1; // default for non-attack items

                    return new InventoryItemDocument
                    {
                        ItemName = item.GetName().GetName(),
                        ItemDurability = durability
                    };
                })
                .ToList()
        };
    }

    public static async Task<Character> ToDomainAsync(CharacterDocument doc, IItemRepository itemRepository)
    {
        if (doc == null)
            throw new ArgumentNullException(nameof(doc));

        var inventoryDomain = new List<Item>();

        foreach (var entry in doc.InventoryList)
        {
            // search item
            Item item = await GetItemByName(new ItemName(entry.ItemName), itemRepository);

            // if attack item apply durability
            if (item is AttackItem attack)
            {
                item = attack.SetDurability(entry.ItemDurability);
            }

            inventoryDomain.Add(item);
        }

        return doc.Type switch
        {
            CharacterType.Warrior => new WarriorCharacter(
                currentHealthPoints: doc.CurrentHealthPoints,
                currentFoodPoints: doc.CurrentFoodPoints,
                currentMoney: doc.CurrentMoney,
                inventoryList: inventoryDomain,
                currentHits: doc.CurrentHits ?? 0  // 0 hit by default
            ),
            CharacterType.Thief => new ThiefCharacter(
                currentHealthPoints: doc.CurrentHealthPoints,
                currentFoodPoints: doc.CurrentFoodPoints,
                currentMoney: doc.CurrentMoney,
                inventoryList: inventoryDomain
            ),
            CharacterType.Berserker => new BerserkerCharacter(
                currentHealthPoints: doc.CurrentHealthPoints,
                currentFoodPoints: doc.CurrentFoodPoints,
                currentMoney: doc.CurrentMoney,
                inventoryList: inventoryDomain,
                currentKills: doc.CurrentKills ?? 0 // 0 kills by default
            ),
            CharacterType.Explorer => new ExplorerCharacter(
                currentHealthPoints: doc.CurrentHealthPoints,
                currentFoodPoints: doc.CurrentFoodPoints,
                currentMoney: doc.CurrentMoney,
                inventoryList: inventoryDomain,
                currentNothingHappensScenesVisited: doc.CurrentNothingHappensScenes ?? 0 // 0 scenes by default
            ),
            _ => throw new ArgumentException($"Unsupported character type: {doc.Type}")
        };
    }


    // GET ITEMS FOR OTHER COLLECTIONS
    private static async Task<Item> GetItemByName(ItemName name, IItemRepository itemRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Item? item = await itemRepository.FetchByName(name);
        if (item == null)
            throw new InvalidOperationException($"Item '{name.GetName()}' not found.");

        return item;
    }
}
