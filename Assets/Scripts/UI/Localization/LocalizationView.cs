using System;
using System.Collections.Generic;
using Constants;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Localization
{
    public class LocalizationView : MonoBehaviour
    {
        [SerializeField] private Button _englishButton;
        [SerializeField] private Button _russianButton;
        [SerializeField] private Button _turkishButton;

        public event Action<string> LanguageChoosed;

        private Dictionary<string, Action> _languages;

        private void OnEnable()
        {
            _englishButton.onClick.AddListener(EnglishButtonClicked);
            _russianButton.onClick.AddListener(RussianButtonClicked);
            _turkishButton.onClick.AddListener(TurkishButtonClicked);
        }

        private void OnDisable()
        {
            _englishButton.onClick.RemoveListener(EnglishButtonClicked);
            _russianButton.onClick.RemoveListener(RussianButtonClicked);
            _turkishButton.onClick.RemoveListener(TurkishButtonClicked);
        }
        
        private void EnglishButtonClicked() =>
            LanguageChoosed?.Invoke(LanguageName.English);

        private void RussianButtonClicked() =>
            LanguageChoosed?.Invoke(LanguageName.Russian);

        private void TurkishButtonClicked() =>
            LanguageChoosed?.Invoke(LanguageName.Turkish);
    }
}