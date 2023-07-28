using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using Cysharp.Threading.Tasks;
using I2.Loc;
using UnityEngine;

namespace Initialize
{
    public class YandexAppConfigurator : IAppConfigurator
    {
        private readonly ICoroutineStarter _coroutineStarter;

        private readonly Dictionary<string, string> _languages = new()
        {
            { "en", "English" },
            { "ru", "Russian" },
            { "tr", "Turkish" },
        };
        
        public YandexAppConfigurator(ICoroutineStarter coroutineStarter)
        {
            _coroutineStarter = coroutineStarter;
            Debug.Log(_coroutineStarter);
        }

        public async UniTask Configure()
        {
            _coroutineStarter.StartCoroutine(ConfigureRoutine());

            while (!YandexGamesSdk.IsInitialized)
            {
                await UniTask.Yield();
            }
        }

        private IEnumerator ConfigureRoutine()
        {
            yield return YandexGamesSdk.Initialize();
            yield return new WaitUntil(() => YandexGamesSdk.IsInitialized);
            YandexGamesSdk.CallbackLogging = true;
            LocalizationManager.CurrentLanguage = YandexGamesSdk.Environment.i18n.lang;
        }
    }
}