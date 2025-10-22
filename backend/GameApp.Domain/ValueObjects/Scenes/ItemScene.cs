using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for a scene where you get an item
public class ItemScene : Scene
{

    public Item RewardItem { get; private set; } = default!;


    // Constructor
    public ItemScene(SceneName name, SceneDescription description, Biomes biome, Item item)
    : base(name, description, biome)
    {
        RewardItem = item;
    }

    // Getter
    public Item GetRewardItem() => RewardItem;

    // Setters 
    public ItemScene SetSceneName(SceneName newName) =>
    new ItemScene(newName, GetDescription(), GetBiome(), RewardItem);

    public ItemScene SetSceneDescription(SceneDescription newDescription) =>
    new ItemScene(GetName(), newDescription, GetBiome(), RewardItem);

    public ItemScene SetBiome(Biomes newBiome) =>
    new ItemScene(GetName(), GetDescription(), newBiome, RewardItem);

    public ItemScene SetItem(Item newItem) =>
    new ItemScene(GetName(), GetDescription(), GetBiome(), newItem);

    // To string
    public override string ToString()
    {
        return $"{GetName()} Item Scene: " +
               $"Description={GetDescription()}, Biome={GetBiome()}, " +
               $"Reward Item={RewardItem}";
    }
}