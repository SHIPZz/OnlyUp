using System;
using DG.Tweening;
using Gameplay;
using Gameplay.Car;
using Invector;
using Invector.vCharacterController;
using UnityEngine;
using Zenject;

public class MovementHandler : IInitializable, IDisposable
{
    private readonly TriggerObserver _triggerObserver;
    private readonly Transform _target;
    private readonly IMovable _movable;

    public MovementHandler(TriggerObserver triggerObserver, Transform target, IMovable movable)
    {
        _triggerObserver = triggerObserver;
        _target = target;
        _movable = movable;
    }

    public void Initialize()
    {
        _triggerObserver.CollisionEntered += MoveToTarget;
    }

    public void Dispose()
    {
        _triggerObserver.CollisionEntered -= MoveToTarget;
    }

    private void MoveToTarget(Collision target)
    {
        // target.gameObject.GetComponent<vThirdPersonController>().TakeDamage(new vDamage(100));
        // target.gameObject.transform.SetParent(_movable.GameObject.transform);
        // _movable.Move(_target.gameObject.transform.position, 3f);
    }
}