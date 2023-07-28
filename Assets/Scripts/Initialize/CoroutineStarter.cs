using UnityEngine;

namespace Initialize
{
    public class CoroutineStarter : MonoBehaviour, ICoroutineStarter
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}