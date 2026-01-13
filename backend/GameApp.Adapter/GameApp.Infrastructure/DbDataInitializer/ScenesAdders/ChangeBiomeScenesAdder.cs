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
            new SceneName("Discovering a forest"),
            new SceneDescription("You catch sight of towering, leafy trees ahead, revealing a beautiful forest brimming with life. "),
            Biome.Forest
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Into the Endless Dunes"),
            new SceneDescription("Suddenly, a suffocating heat hits you as the landscape opens before your eyes. Endless sand dunes stretch as far as you can see, shimmering under the relentless sun."),
            Biome.Desert
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Arriving at the Bustling City"),
            new SceneDescription("The sounds and commotion of people draw your attention. Before you rises a sprawling city, filled with shops and streets teeming with life, inviting you to explore its many corners"),
            Biome.City
        ));

        scenesToAdd.Add(new ChangeBiomeScene(
            new SceneName("Into the Murky Swamp"),
            new SceneDescription("The air grows heavy and damp, carrying a sharp, unpleasant odor. Dark, treacherous waters stretch around you, and countless hidden creatures lurk beneath, making every step potentially deadly."),
            Biome.Swamp
        ));


        scenes.AddRange(scenesToAdd);
    }
}