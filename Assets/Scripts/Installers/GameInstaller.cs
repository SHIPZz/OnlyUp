using Gameplay;
using Gameplay.Character;
using Services;
using Services.Factories;
using Services.Providers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPosition;
        
        public override void InstallBindings()
        {
            BindLocationProvider();
            BindGameInit();
            BindGameFactory();
            BindPlayerFactory();
            BindAssetProvider();
            BindPlayerProvider();
            BindPlayerDeactivatorHandler();
            BindPauseOnAd();
        }

        private void BindPauseOnAd()
        {
            Container
                .BindInterfacesAndSelfTo<PauseOnAd>()
                .AsSingle();
        }

        private void BindPlayerDeactivatorHandler()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerDeactivatorHandler>()
                .AsSingle();
        }

        private void BindPlayerProvider()
        {
            Container
                .Bind<PlayerProvider>()
                .AsSingle();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<AssetProvider>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<GameFactory>()
                .AsSingle();
        }

        private void BindGameInit()
        {
            Container
                .BindInterfacesAndSelfTo<GameInit.GameInit>()
                .AsSingle();
            
        }

        private void BindPlayerFactory()
        {
            Container
                .Bind<PlayerFactory>()
                .AsSingle();
        }

        private void BindLocationProvider()
        {
            var locationProvider = new LocationProvider(_playerSpawnPosition);
            Container.BindInstance(locationProvider);
        }
    }
}