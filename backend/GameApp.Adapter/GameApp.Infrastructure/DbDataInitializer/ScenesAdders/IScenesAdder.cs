using GameApp.Domain.Entities;
using GameApp.Domain.Entities.Scenes;

namespace GameApp.Adapter.Infrastructure.DbDataInitializer.ScenesAdders;

// Interface for scenes adder to feed initial db
public interface IScenesAdder
{
    static abstract void AddScenes(List<Scene> scenes);
}