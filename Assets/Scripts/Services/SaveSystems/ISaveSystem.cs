using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Services.SaveSystems
{
    public interface ISaveSystem
    {
        void Save(GameData gameData);
        UniTask<GameData> Load();
    }
}