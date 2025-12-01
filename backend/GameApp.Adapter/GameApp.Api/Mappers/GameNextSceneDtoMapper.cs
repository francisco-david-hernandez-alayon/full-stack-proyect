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
            Character character = CharacterDtoMapper.ToDomain(dto.Character);
            NothingHappensScene finalScene = FinalSceneDtoMapper.ToDomain(dto.FinalScene);
            List<Scene> completedScenes = dto.ListCompletedScenes.Select(SceneDtoMapper.ToDomain).ToList();
            List<Scene> currentScenes = dto.ListCurrentScenes.Select(SceneDtoMapper.ToDomain).ToList();
            List<UserAction> currentUserActions = dto.ListCurrentUserActions.ToList();
            Enemy? currentEnemy = dto.CurrentEnemy != null ? EnemyDtoMapper.ToDomainPosibleNull(dto.CurrentEnemy) : null;

            return new Game(
                dto.Id,
                character,
                dto.NumberScenesToFinish,
                completedScenes,
                finalScene,
                currentScenes,
                currentUserActions,
                currentEnemy
            );
        }
    }
}
