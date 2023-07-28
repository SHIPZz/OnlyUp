using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using I2.Loc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Initialize
{
    public class Initialize : MonoBehaviour
    {
        private readonly Dictionary<string, string> _languages = new()
        {
            { "en", "English" },
            { "ru", "Russian" },
            { "tr", "Turkish" },
        };
        
        private void Awake()
        {
            StartCoroutine(Init());
        }

        private IEnumerator Init()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            StartGame();
            yield break;
#endif
            yield return YandexGamesSdk.Initialize();
            YandexGamesSdk.CallbackLogging = true;
            LocalizationManager.CurrentLanguage = _languages[YandexGamesSdk.Environment.i18n.lang];
            StartGame();
        }
    
        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}