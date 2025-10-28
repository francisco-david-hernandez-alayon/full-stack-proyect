using System.Collections.Generic;
using System.Linq;
using GameApp.Api.dtos;
using GameApp.Domain.Entities;


namespace GameApp.Api.Mappers
{
    public static class GameDtoMapper
    {

        public static Game ToDomain(GameResponseDto dto)
        {
            var character = CharacterDtoMapper.ToDomain(dto.Character);
            var finalScene = FinalSceneDtoMapper.ToDomain(dto.FinalScene);

            return new Game(
                character,
                dto.NumberScenesToFinish,
                finalScene
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
                FinalScene = FinalSceneDtoMapper.ToDto(game.GetFinalScene())
            };
        }

        public static List<GameResponseDto> ToDtoList(IEnumerable<Game> games)
        {
            return games.Select(ToDto).ToList();
        }
    }
}
