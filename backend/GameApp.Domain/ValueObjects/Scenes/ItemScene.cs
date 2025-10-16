using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Items;

namespace GameApp.Domain.ValueObjects.Scenes;

// Class for a scene where you get an item
public class ItemScene : Scene
{

    private readonly Item _rewardItem;

    // Constructor
    public ItemScene(SceneName name, SceneDescription description, Biomes biome, Item item)
    : base(name, description, biome)
    {
        _rewardItem = item;
    }

    // Getter
    public Item GetRewardItem() => _rewardItem;

    // Setters 
    public ItemScene SetSceneName(SceneName newName) =>
    new ItemScene(newName, GetDescription(), GetBiomes(), _rewardItem);

    public ItemScene SetSceneDescription(SceneDescription newDescription) =>
    new ItemScene(GetName(), newDescription, GetBiomes(), _rewardItem);

    public ItemScene SetBiome(Biomes newBiome) =>
    new ItemScene(GetName(), GetDescription(), newBiome, _rewardItem);

    public ItemScene SetItem(Item newItem) =>
    new ItemScene(GetName(), GetDescription(), GetBiomes(), newItem);

    // To string
    public override string ToString()
    {
        return $"{_name.GetName()} Item Scene: " +
               $"Description={_description}, Biome={_biome}, " +
               $"Reward Item={_rewardItem}";
    }
}