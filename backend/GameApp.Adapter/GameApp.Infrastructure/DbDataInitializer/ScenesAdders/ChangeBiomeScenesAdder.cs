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
            new SceneName("Change Biome Forest 1"),
            new SceneDescription("A narrow path opens, leading you into a deep forest."),
            Biome.forest
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome Desert 1"),
            new SceneDescription("The terrain shifts into endless dunes as you enter the desert."),
            Biome.desert
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome City 1"),
            new SceneDescription("Ruins and stone roads appear as you arrive at an abandoned city."),
            Biome.city
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Change Biome Swamp 1"),
            new SceneDescription("The ground turns wet and murky as you step into a dark swamp."),
            Biome.swamp
        ));

        scenes.AddRange(scenesToAdd);
    }
}