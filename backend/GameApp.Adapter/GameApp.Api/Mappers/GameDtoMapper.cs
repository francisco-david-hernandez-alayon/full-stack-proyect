using GameApp.Adapter.Api.dtos.GamesDto;
using GameApp.Domain.Entities;


namespace GameApp.Adapter.Api.Mappers
{
    public static class GameDtoMapper
    {

        public static Game ToDomain(GameResponseDto dto)
        {
            var character = CharacterDtoMapper.ToDomain(dto.Character);
            var finalScene = FinalSceneDtoMapper.ToDomain(dto.FinalScene);
            var currentScenes = dto.ListCurrentScenes.Select(SceneDtoMapper.ToDomain).ToList();
            var currentUserActions = dto.ListCurrentUserActions.ToList();

            return new Game(
                character,
                dto.NumberScenesToFinish,
                finalScene,
                currentScenes,
                currentUserActions
            );
        }
        
        public static GameResponseDto ToDto(Game game)
        {

            return new GameResponseDto
            {
                Id = game.GetGuid(),
                Character = CharacterDtoMapper.ToDto(game.GetCharacter()),
                NumberScenesToFinish = game.GetNumberScenesToFinish(),
                ListCompletedScenes = game.GetCompletedScenes().Select(SceneDtoMapper.ToDto).ToList(),
                ListCurrentScenes = game.GetCurrentScenes().Select(SceneDtoMapper.ToDto).ToList(),
                ListCurrentUserActions = game.GetCurrentUserAction().ToList(),
                FinalScene = FinalSceneDtoMapper.ToDto(game.GetFinalScene()),
                CurrentEnemy = EnemyDtoMapper.ToDtoPosibleNull(game.GetCurrentEnemy()),
            };
        }

        public static List<GameResponseDto> ToDtoList(IEnumerable<Game> games)
        {
            return games.Select(ToDto).ToList();
        }
    }
}
