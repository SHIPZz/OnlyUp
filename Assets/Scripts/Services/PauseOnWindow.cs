using UI;
using UnityEngine;

namespace Services
{
    public class PauseOnWindow : MonoBehaviour
    {
        [SerializeField] private Window _window;

        private void OnEnable()
        {
            _window.Opened += SetPause;
            _window.Closed += UnPause;
        }

        private void OnDisable()
        {
            _window.Opened -= SetPause;
            _window.Closed -= UnPause;
        }

        private void UnPause() => 
            Time.timeScale = 1f;

        private void SetPause() => 
            Time.timeScale = 0f;
    }
}