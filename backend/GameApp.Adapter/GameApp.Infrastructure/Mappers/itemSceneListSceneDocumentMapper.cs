using GameApp.Adapter.Infrastructure.Models;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Repositories;
using GameApp.Domain.ValueObjects.Scenes;

public static class itemSceneListSceneDocumentMapper
{

    public static ItemSceneListDocument ToItemSceneListDocument(Scene scene)
    {
        var doc = new ItemSceneListDocument
        {
            SceneName = scene.GetName().GetName()
        };

        if (scene is TradeScene tradeScene)
        {
            doc.tradeSceneMerchantMoneyToSpent = tradeScene.GetMerchantMoneyToSpent();
        }

        return doc;
    }


    public static async Task<Scene> ToSceneDomainAsync(
    ItemSceneListDocument doc,
    ISceneRepository sceneRepository
)
    {
        Scene baseScene = await GetSceneByName(
            new SceneName(doc.SceneName),
            sceneRepository
        );


        if (baseScene is TradeScene tradeScene &&
            doc.tradeSceneMerchantMoneyToSpent.HasValue)
        {
            return tradeScene.SetMerchantMoneyToSpent(
                doc.tradeSceneMerchantMoneyToSpent.Value
            );
        }

        return baseScene;
    }


    private static async Task<Scene> GetSceneByName(SceneName name, ISceneRepository sceneRepository)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        Scene? scene = await sceneRepository.FetchByName(name);
        if (scene == null)
            throw new InvalidOperationException($"Scene '{name.GetName()}' not found.");

        return scene;
    }

}