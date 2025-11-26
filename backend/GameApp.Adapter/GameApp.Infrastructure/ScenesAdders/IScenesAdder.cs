using GameApp.Domain.Entities;

namespace GameApp.Host.scenes;

// Interface for scenes adder to feed initial db
public interface IScenesAdder
{
    static abstract void AddScenes(List<Scene> scenes);
}