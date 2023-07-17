using Invector.vCharacterController;
using UnityEngine;
using Zenject;

namespace Gameplay.Character
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerRaycastDownHitChecker _playerRaycastDownHitChecker;
        [SerializeField] private vThirdPersonController _vThirdPersonController;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerRaycastDownHitChecker);
            Container.BindInstance(_vThirdPersonController);
            Container.BindInterfacesAndSelfTo<PlayerPositionRestorerMediator>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerPositionRestorer>().AsSingle();
        }
    }
}