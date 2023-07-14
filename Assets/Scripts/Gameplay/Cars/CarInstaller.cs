using Gameplay.Car;
using UnityEngine;
using Zenject;

namespace Gameplay.Cars
{
    public class CarInstaller : MonoInstaller
    {
        [SerializeField] private Car _car;
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private Transform _targetToMove;
        [SerializeField] private Rigidbody _rigidbody;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IMovable>().To<Car>()
                .FromInstance(_car);

            Container.BindInterfacesAndSelfTo<MovementHandler>()
                .AsSingle();

            Container.BindInstance(_triggerObserver);
            Container.BindInstance(_targetToMove);
            Container.BindInstance(_rigidbody);
        }
    }
}