using System.Text.Json;
using GameApp.Adapter.Api.dtos.GamesDto;
using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;
using GameApp.Domain.Enumerates;
using GameApp.Domain.ValueObjects.Characters;

namespace GameApp.Adapter.Api.Mappers
{
    public static class GameNextSceneDtoMapper
    {
        public static Game ToDomain(GameNextSceneRequestDto dto)
        {
            var gameDto = dto.Game;

            Character character = CharacterDtoMapper.ToDomain(gameDto.Character);

            FinalScene finalScene = FinalSceneDtoMapper.ToDomain(gameDto.FinalScene);

            List<Scene> completedScenes = gameDto.ListCompletedScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();

            List<Scene> currentScenes = gameDto.ListCurrentScenes?
                .Select(SceneDtoMapper.ToDomain)
                .ToList() ?? new List<Scene>();

            List<UserAction> currentUserActions = gameDto.ListCurrentUserActions ?? new List<UserAction>();

            Enemy? currentEnemy = EnemyDtoMapper.ToDomainPosibleNull(gameDto.CurrentEnemy);

            return new Game(
                dto.Id,
                gameDto.Difficulty,
                character,
                gameDto.NumberScenesToFinish,
                completedScenes,
                finalScene,
                currentScenes,
                currentUserActions,
                gameDto.Status,
                currentEnemy
            );
        }
    }
}
