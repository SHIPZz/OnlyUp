using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.SaveSystems
{
    public class PlayerPrefsSystem : ISaveSystem
    {
        private const string DataKey = "GameData";
        
        public void Save(GameData gameData)
        {
            string data = JsonUtility.ToJson(gameData);

            PlayerPrefs.SetString(DataKey, data);
            PlayerPrefs.Save();
        }

        public async UniTask<GameData> Load()
        {
            if (PlayerPrefs.HasKey(DataKey))
            {
                string data = PlayerPrefs.GetString(DataKey);
                var gameData = JsonUtility.FromJson<GameData>(data);
                return gameData;
            }

            await UniTask.Yield();

            return new GameData();
        }
    }
}