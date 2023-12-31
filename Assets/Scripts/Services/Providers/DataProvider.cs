﻿using Cysharp.Threading.Tasks;
using Services.SaveSystems;
using UnityEngine;

namespace Services.Providers
{
    public class DataProvider
    {
        private readonly ISaveSystem _saveSystem;
        private GameData _gameData = new();

        public DataProvider(ISaveSystem saveSystem) => 
            _saveSystem = saveSystem;

        public void SaveVolume(float volume)
        {
            _gameData.Volume = volume;
            _saveSystem.Save(_gameData);
        }

        public float GetVolume() =>
            _gameData.Volume;

        public void SaveLanguage(string language)
        {
            _gameData.Language = language;
            _saveSystem.Save(_gameData);
        }
        
        public void SaveLastPosition(Vector3 targetPosition)
        {
            _gameData.PositionX = targetPosition.x;
            _gameData.PositionY = targetPosition.y;
            _gameData.PositionZ = targetPosition.z;
            _saveSystem.Save(_gameData);
        }

        public Vector3 GetLastPosition()
        {
            var targetPosition = new Vector3(_gameData.PositionX,
                _gameData.PositionY, _gameData.PositionZ);
            return targetPosition;
        }

        public async UniTask LoadInitialData()
        {
            _gameData = await _saveSystem.Load();
        }
    }
}