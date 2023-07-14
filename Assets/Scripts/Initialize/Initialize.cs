using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Initialize
{
    public class Initialize : MonoBehaviour
    {
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
            StartGame();
        }
    
        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
