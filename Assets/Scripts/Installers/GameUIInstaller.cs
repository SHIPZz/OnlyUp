using Services;
using Services.Providers;
using Services.UIServices;
using UI;
using UI.Ad;
using UI.Audio;
using UI.InputUI;
using UI.Localization;
using UI.Settings;
using UI.Victory;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] private WindowProvider _windowProvider;
        [SerializeField] private AudioVolumeView _audioVolumeView;
        [SerializeField] private PlayerEndPointChecker _playerEndPointChecker;
        [SerializeField] private LocalizationView _localizationView;
        [SerializeField] private SettingView _settingView;
        [SerializeField] private AdsButtonHandler _adsButtonHandler;
        
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
        }

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

        private void BindPlayerEndPointChecker()
        {
            Container
                .BindInstance(_playerEndPointChecker);
        }

        private void BindVictoryUI()
        {
            Container
                .BindInterfacesAndSelfTo<VictoryPresenter>()
                .AsSingle();
        }

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

            Container.BindInstance(_adsButtonHandler);
        }

        private void BindWindowService()
        {
            Container
                .Bind<WindowService>()
                .AsSingle();
        }

        private void BindWindowProvider()
        {
            Container.BindInstance(_windowProvider);
        }
    }
}