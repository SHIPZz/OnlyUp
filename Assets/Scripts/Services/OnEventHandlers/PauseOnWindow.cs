using UI;
using UI.Windows;
using UnityEngine;

namespace Services.OnEventHandlers
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