using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

public class ChangeBiomesScenesAdder : IScenesAdder
{

    public static void AddScenes(List<Scene> scenes)
    {
        List<Scene> scenesToAdd = new List<Scene>();

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome Forest"),
            new SceneDescription("A narrow path opens, leading you into a deep forest."),
            Biome.Forest
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome Desert"),
            new SceneDescription("The terrain shifts into endless dunes as you enter the desert."),
            Biome.Desert
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome City"),
            new SceneDescription("Ruins and stone roads appear as you arrive at an abandoned city."),
            Biome.City
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome Swamp"),
            new SceneDescription("The ground turns wet and murky as you step into a dark swamp."),
            Biome.Swamp
        ));

        scenes.AddRange(scenesToAdd);
    }
}