using Gameplay.Character;
using Services;
using Services.OnEventHandlers;
using Services.Providers;
using Services.UIServices;
using UI;
using UI.Audio;
using UI.Localization;
using UI.Windows.Ad;
using UI.Windows.InputUI;
using UI.Windows.Settings;
using UI.Windows.Victory;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _mainUI;
        [SerializeField] private WindowProvider _windowProvider;
        [SerializeField] private AudioVolumeView _audioVolumeView;
        [SerializeField] private PlayerEndPointChecker _playerEndPointChecker;
        [SerializeField] private LocalizationView _localizationView;
        [SerializeField] private SettingView _settingView;
        [SerializeField] private AdButtonView _adButtonView;
        
        public override void InstallBindings()
        {
            BindWindowProvider();
            BindWindowService();
            BindAdUI();
            BindAudioChanging();
            BindVictoryUI();
            BindPlayerEndPointChecker();
            BindLocalizationUI();
            BindSettingUI();
            // BindMobileInputUI();
            BindScreenTouchBlocker();
            BindShowerCursorOn();
            BindMainUI();
        }

        private void BindMainUI() => 
            Container.BindInstance(_mainUI);

        private void BindShowerCursorOn() =>
            Container
                .BindInterfacesAndSelfTo<ShowerCursorOn>()
                .AsSingle();

        private void BindScreenTouchBlocker() =>
            Container
                .BindInterfacesAndSelfTo<ScreenTouchBlocker>()
                .AsSingle();

        private void BindMobileInputUI()
        {
            Container
                .BindInterfacesAndSelfTo<MobileInputPresenter>()
                .AsSingle();
        }

        private void BindSettingUI()
        {
            Container
                .BindInterfacesAndSelfTo<SettingWindowPresenter>()
                .AsSingle();

            Container.BindInstance(_settingView);
        }

        private void BindLocalizationUI()
        {
            Container
                .BindInterfacesAndSelfTo<LocalizationPresenter>()
                .AsSingle();

            Container.BindInstance(_localizationView);
            
            Container.Bind<LocalizationChanger>()
                .AsSingle();
        }

        private void BindPlayerEndPointChecker() =>
            Container
                .BindInstance(_playerEndPointChecker);

        private void BindVictoryUI() =>
            Container
                .BindInterfacesAndSelfTo<VictoryPresenter>()
                .AsSingle();

        private void BindAudioChanging()
        {
            Container
                .BindInstance(_audioVolumeView);

            Container
                .BindInterfacesAndSelfTo<AudioVolumeChanger>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<AudioPresenter>()
                .AsSingle();
        }

        private void BindAdUI()
        {
            Container
                .BindInterfacesAndSelfTo<AdPresenter>()
                .AsSingle();
            
            Container.BindInstance(_adButtonView);

            Container
                .BindInterfacesAndSelfTo<AdShowerOnButton>()
                .AsSingle();
        }

        private void BindWindowService() =>
            Container
                .Bind<WindowService>()
                .AsSingle();

        private void BindWindowProvider() => 
            Container.BindInstance(_windowProvider);
    }
}