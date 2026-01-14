using GameApp.Domain.Enumerates;

public record SceneGoodnessWeights
{
    public static readonly Dictionary<GameDifficulty, Dictionary<SceneGoodness, int>> Weights = new Dictionary<GameDifficulty, Dictionary<SceneGoodness, int>>
    {
        [GameDifficulty.Easy] = new Dictionary<SceneGoodness, int>
        {
            [SceneGoodness.VeryGood] = 7,
            [SceneGoodness.Good] = 10,
            [SceneGoodness.Normal] = 10,
            [SceneGoodness.Bad] = 5,
            [SceneGoodness.VeryBad] = 3
        },

        [GameDifficulty.Normal] = new Dictionary<SceneGoodness, int>
        {
            [SceneGoodness.VeryGood] = 5,
            [SceneGoodness.Good] = 8,
            [SceneGoodness.Normal] = 10,
            [SceneGoodness.Bad] = 7,
            [SceneGoodness.VeryBad] = 5
        },

        [GameDifficulty.Hard] = new Dictionary<SceneGoodness, int>
        {
            [SceneGoodness.VeryGood] = 3,
            [SceneGoodness.Good] = 5,
            [SceneGoodness.Normal] = 10,
            [SceneGoodness.Bad] = 10,
            [SceneGoodness.VeryBad] = 7
        }
    };
}
