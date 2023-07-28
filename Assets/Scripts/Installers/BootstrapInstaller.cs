using Agava.YandexGames;
using Initialize;
using Services.Providers;
using Services.SaveSystems;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindDataProvider();
            BindSaveSystem();
        }

        private void BindDataProvider()
        {
            Container
                .Bind<DataProvider>()
                .AsSingle();
        }

        private void BindSaveSystem()
        {
            if (PlayerAccount.IsAuthorized)
                Container.Bind<ISaveSystem>()
                    .To<YandexSaveSystem>()
                    .AsSingle();
            else
                Container
                    .Bind<ISaveSystem>()
                    .To<PlayerPrefsSystem>()
                    .AsSingle();
        }
    }
}