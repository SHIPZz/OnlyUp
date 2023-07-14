using System.Threading.Tasks;

namespace Services.SaveSystems
{
    public interface ISaveSystem
    {
        void Save(GameData gameData);
        Task<GameData> Load();
    }
}