using System;
using Gameplay.Character;
using Invector;
using Invector.vCharacterController;
using UnityEngine;

namespace Services.Providers
{
    public class PlayerProvider
    {
        public vThirdPersonController Player
        {
            get => Player;
            set => PlayerInstalled?.Invoke(value);
        }

        public PlayerRaycastDownHitChecker PlayerRaycastDownHitChecker
        {
            get => PlayerRaycastDownHitChecker;
            set => PlayerRaycastDownInstalled?.Invoke(value);
        }
        
        public vFootStep vFootStep
        {
            get => vFootStep;
            set => PlayerFootStepInstalled?.Invoke(value);
        }

        public event Action<vThirdPersonController> PlayerInstalled;
        public event Action<PlayerRaycastDownHitChecker> PlayerRaycastDownInstalled;
        public event Action<vFootStep> PlayerFootStepInstalled;
    }
}