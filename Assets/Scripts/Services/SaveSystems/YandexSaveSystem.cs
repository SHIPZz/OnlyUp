using Agava.YandexGames;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.SaveSystems
{
    public class YandexSaveSystem : ISaveSystem
    {
        private GameData _gameData;
        private bool _isSaveDataReceived;

        public void Save(GameData gameData)
        {
            string data = JsonUtility.ToJson(gameData);

            PlayerAccount.SetCloudSaveData(data);
        }

        public async  UniTask<GameData> Load()
        {
            PlayerAccount.GetCloudSaveData(OnSuccessCallback);

            while (_gameData is null)
            {
                await UniTask.Yield();
            }
        
            return _gameData;
        }

        private GameData ConvertJsonToGameData(string data) =>
            string.IsNullOrEmpty(data) ? new GameData() : JsonUtility.FromJson<GameData>(data);

        private void OnSuccessCallback(string data)
        {
            _gameData = ConvertJsonToGameData(data);
            _isSaveDataReceived = true;
        }
    }
}